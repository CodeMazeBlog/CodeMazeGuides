using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqVsKafka;

public record RabbitQueueResult(
    IReadOnlyList<int> Billed, int DeadLetteredOrderId, string DeadLetterReason, int PoisonAttempts, bool LateConsumerGotAnything);

public class RabbitQueueDemo(string connectionString)
{
    public async Task<RabbitQueueResult> RunAsync()
    {
        var factory = new ConnectionFactory { Uri = new Uri(connectionString) };
        await using var connection = await factory.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync(new CreateChannelOptions(
            publisherConfirmationsEnabled: true, publisherConfirmationTrackingEnabled: true));

        await channel.QueueDeclareAsync("orders.dlq", durable: true, exclusive: false, autoDelete: false);
        await channel.QueueDeclareAsync("orders", durable: true, exclusive: false, autoDelete: false,
            arguments: new Dictionary<string, object?>
            {
                ["x-queue-type"] = "quorum",
                ["x-delivery-limit"] = 2,
                ["x-dead-letter-exchange"] = "",
                ["x-dead-letter-routing-key"] = "orders.dlq"
            });

        foreach (var order in OrderPlaced.Samples)
        {
            await channel.BasicPublishAsync(exchange: "", routingKey: "orders",
                body: JsonSerializer.SerializeToUtf8Bytes(order));
            Console.WriteLine($"RabbitMQ: published order {order.OrderId}, broker confirmed");
        }

        var billed = new List<int>();
        var poisonAttempts = 0;
        var allBilled = new TaskCompletionSource();
        await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

        var billing = new AsyncEventingBasicConsumer(channel);
        billing.ReceivedAsync += async (_, delivery) =>
        {
            var order = JsonSerializer.Deserialize<OrderPlaced>(delivery.Body.Span)!;
            if (order.CanBeBilled)
            {
                await channel.BasicAckAsync(delivery.DeliveryTag, multiple: false);
                billed.Add(order.OrderId);
                Console.WriteLine($"RabbitMQ billing: billed order {order.OrderId}, ack");
                if (billed.Count == OrderPlaced.Samples.Count(o => o.CanBeBilled)) allBilled.TrySetResult();
                return;
            }

            poisonAttempts++;
            Console.WriteLine($"RabbitMQ billing: order {order.OrderId} failed, redelivered: {delivery.Redelivered}, " +
                $"x-delivery-count: {Header(delivery.BasicProperties, "x-delivery-count") ?? 0}, reject and requeue");
            await channel.BasicRejectAsync(delivery.DeliveryTag, requeue: true);
        };
        await channel.BasicConsumeAsync("orders", autoAck: false, consumer: billing);

        var deadLetter = new TaskCompletionSource<(int OrderId, string Reason)>();
        var dlqReader = new AsyncEventingBasicConsumer(channel);
        dlqReader.ReceivedAsync += (_, delivery) =>
        {
            var order = JsonSerializer.Deserialize<OrderPlaced>(delivery.Body.Span)!;
            var reason = (string)Header(delivery.BasicProperties, "x-first-death-reason")!;
            Console.WriteLine($"RabbitMQ: order {order.OrderId} arrived in orders.dlq, reason: {reason}");
            deadLetter.TrySetResult((order.OrderId, reason));
            return Task.CompletedTask;
        };
        await channel.BasicConsumeAsync("orders.dlq", autoAck: true, consumer: dlqReader);

        await Task.WhenAll(allBilled.Task, deadLetter.Task).WaitAsync(TimeSpan.FromSeconds(30));

        var late = await channel.BasicGetAsync("orders", autoAck: true);
        Console.WriteLine($"RabbitMQ: a consumer that starts now gets {(late is null ? "nothing" : "a message")}");

        var (deadOrderId, deadReason) = await deadLetter.Task;
        return new RabbitQueueResult(billed, deadOrderId, deadReason, poisonAttempts, late is not null);
    }

    public static object? Header(IReadOnlyBasicProperties properties, string name) =>
        properties.Headers is not null && properties.Headers.TryGetValue(name, out var value)
            ? value is byte[] text ? Encoding.UTF8.GetString(text) : value
            : null;
}
