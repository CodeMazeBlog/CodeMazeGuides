using System.Text.Json;
using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace RabbitMqVsKafka;

public record KafkaResult(
    IReadOnlyList<int> Billed, IReadOnlyList<int> DeadLettered, IReadOnlyList<int> Analytics, IReadOnlyList<int> Replayed);

public class KafkaDemo(string bootstrapServers)
{
    private const int MaxAttempts = 3;

    public async Task<KafkaResult> RunAsync()
    {
        await CreateTopicsAsync();
        var startedAt = DateTime.UtcNow;

        using var producer = new ProducerBuilder<string, string>(
            new ProducerConfig { BootstrapServers = bootstrapServers }).Build();
        foreach (var order in OrderPlaced.Samples)
        {
            var sent = await producer.ProduceAsync("orders", new Message<string, string>
            {
                Key = order.OrderId.ToString(),
                Value = JsonSerializer.Serialize(order)
            });
            Console.WriteLine($"Kafka: produced order {order.OrderId} to partition {sent.Partition.Value}, offset {sent.Offset.Value}");
        }

        var (billed, deadLettered) = await BillAsync(producer);
        var analytics = Read("analytics", consumer => consumer.Subscribe("orders"));
        var replayed = Read("billing-replay", consumer =>
        {
            var fromTime = Enumerable.Range(0, 3)
                .Select(partition => new TopicPartitionTimestamp("orders", partition, new Timestamp(startedAt)));
            consumer.Assign(consumer.OffsetsForTimes(fromTime, TimeSpan.FromSeconds(10)));
        });

        return new KafkaResult(billed, deadLettered, analytics, replayed);
    }

    private async Task<(List<int> Billed, List<int> DeadLettered)> BillAsync(IProducer<string, string> producer)
    {
        var billed = new List<int>();
        var deadLettered = new List<int>();
        var attempts = new Dictionary<int, int>();

        using var consumer = CreateConsumer("billing");
        consumer.Subscribe("orders");

        while (billed.Count + deadLettered.Count < OrderPlaced.Samples.Count)
        {
            var record = consumer.Consume(TimeSpan.FromSeconds(30))!;
            var order = JsonSerializer.Deserialize<OrderPlaced>(record.Message.Value)!;
            var where = $"partition {record.Partition.Value}, offset {record.Offset.Value}";

            if (order.CanBeBilled)
            {
                consumer.Commit(record);
                billed.Add(order.OrderId);
                Console.WriteLine($"Kafka billing: billed order {order.OrderId} ({where}), commit");
                continue;
            }

            attempts[order.OrderId] = attempts.GetValueOrDefault(order.OrderId) + 1;
            if (attempts[order.OrderId] < MaxAttempts)
            {
                Console.WriteLine($"Kafka billing: order {order.OrderId} failed ({where}), attempt {attempts[order.OrderId]}, seek back");
                consumer.Seek(record.TopicPartitionOffset);
                continue;
            }

            await producer.ProduceAsync("orders.dlq", record.Message);
            consumer.Commit(record);
            deadLettered.Add(order.OrderId);
            Console.WriteLine($"Kafka billing: order {order.OrderId} failed {MaxAttempts} times, produced to orders.dlq, commit");
        }

        consumer.Close();
        return (billed, deadLettered);
    }

    private List<int> Read(string groupId, Action<IConsumer<string, string>> start)
    {
        var received = new List<int>();
        using var consumer = CreateConsumer(groupId);
        start(consumer);

        while (received.Count < OrderPlaced.Samples.Count)
        {
            var record = consumer.Consume(TimeSpan.FromSeconds(30))!;
            var order = JsonSerializer.Deserialize<OrderPlaced>(record.Message.Value)!;
            received.Add(order.OrderId);
            Console.WriteLine($"Kafka {groupId}: read order {order.OrderId} (partition {record.Partition.Value}, offset {record.Offset.Value})");
        }

        consumer.Close();
        return received;
    }

    private IConsumer<string, string> CreateConsumer(string groupId) =>
        new ConsumerBuilder<string, string>(new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        }).Build();

    private async Task CreateTopicsAsync()
    {
        using var admin = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = bootstrapServers }).Build();
        try
        {
            await admin.CreateTopicsAsync(
            [
                new TopicSpecification { Name = "orders", NumPartitions = 3, ReplicationFactor = 1 },
                new TopicSpecification { Name = "orders.dlq", NumPartitions = 1, ReplicationFactor = 1 }
            ]);
        }
        catch (CreateTopicsException e) when (e.Results.All(r => r.Error.Code == ErrorCode.TopicAlreadyExists))
        {
        }
    }
}
