using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqVsKafka;

public class RabbitStreamDemo(string connectionString)
{
    public async Task<(IReadOnlyList<int> First, IReadOnlyList<int> Second)> RunAsync()
    {
        var factory = new ConnectionFactory { Uri = new Uri(connectionString) };
        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync(new CreateChannelOptions(
            publisherConfirmationsEnabled: true, publisherConfirmationTrackingEnabled: true));

        await channel.QueueDeclareAsync("orders.stream", durable: true, exclusive: false, autoDelete: false,
            arguments: new Dictionary<string, object?> { ["x-queue-type"] = "stream" });

        foreach (var order in OrderPlaced.Samples)
        {
            await channel.BasicPublishAsync(exchange: "", routingKey: "orders.stream",
                body: JsonSerializer.SerializeToUtf8Bytes(order));
        }

        var first = await ReadFromStartAsync(channel, "first reader");
        var second = await ReadFromStartAsync(channel, "second reader");
        return (first, second);
    }

    private static async Task<List<int>> ReadFromStartAsync(IChannel channel, string reader)
    {
        var received = new List<int>();
        var done = new TaskCompletionSource();
        await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 100, global: false);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (_, delivery) =>
        {
            var order = JsonSerializer.Deserialize<OrderPlaced>(delivery.Body.Span)!;
            await channel.BasicAckAsync(delivery.DeliveryTag, multiple: false);
            received.Add(order.OrderId);
            Console.WriteLine($"RabbitMQ stream, {reader}: order {order.OrderId}, " +
                $"x-stream-offset {RabbitQueueDemo.Header(delivery.BasicProperties, "x-stream-offset")}, ack");
            if (received.Count == OrderPlaced.Samples.Count) done.TrySetResult();
        };

        var consumerTag = await channel.BasicConsumeAsync("orders.stream", autoAck: false, consumerTag: "",
            arguments: new Dictionary<string, object?> { ["x-stream-offset"] = "first" }, consumer: consumer);
        await done.Task.WaitAsync(TimeSpan.FromSeconds(30));
        await channel.BasicCancelAsync(consumerTag);
        return received;
    }
}
