using Testcontainers.Kafka;
using Testcontainers.RabbitMq;

[assembly: CaptureConsole]

namespace RabbitMqVsKafka.Tests;

public class BrokerTests
{
    private static readonly int[] GoodOrders = [1001, 1002, 1004, 1005];
    private static readonly int[] AllOrders = [1001, 1002, 1003, 1004, 1005];

    [Fact]
    public async Task RabbitQueue_AcksGoodOrders_DeadLettersPoisonOrder_LeavesNothingForLateConsumer()
    {
        await using var rabbitMq = new RabbitMqBuilder("rabbitmq:4.3.6-management").Build();
        await rabbitMq.StartAsync(TestContext.Current.CancellationToken);

        var result = await new RabbitQueueDemo(rabbitMq.GetConnectionString()).RunAsync();

        Assert.Equal(GoodOrders, result.Billed.Order());
        Assert.Equal(1003, result.DeadLetteredOrderId);
        Assert.Equal("delivery_limit", result.DeadLetterReason);
        Assert.Equal(3, result.PoisonAttempts);
        Assert.False(result.LateConsumerGotAnything);
    }

    [Fact]
    public async Task Kafka_CommitsGoodOrders_DeadLettersPoisonOrder_SecondGroupAndReplayReadAllFive()
    {
        await using var kafka = new KafkaBuilder("apache/kafka:4.3.1").Build();
        await kafka.StartAsync(TestContext.Current.CancellationToken);

        var result = await new KafkaDemo(kafka.GetBootstrapAddress()).RunAsync();

        Assert.Equal(GoodOrders, result.Billed.Order());
        Assert.Equal([1003], result.DeadLettered);
        Assert.Equal(AllOrders, result.Analytics.Order());
        Assert.Equal(AllOrders, result.Replayed.Order());
    }

    [Fact]
    public async Task RabbitStream_TwoReadersFromFirstOffset_BothReadAllFive()
    {
        await using var rabbitMq = new RabbitMqBuilder("rabbitmq:4.3.6-management").Build();
        await rabbitMq.StartAsync(TestContext.Current.CancellationToken);

        var (first, second) = await new RabbitStreamDemo(rabbitMq.GetConnectionString()).RunAsync();

        Assert.Equal(AllOrders, first);
        Assert.Equal(AllOrders, second);
    }
}
