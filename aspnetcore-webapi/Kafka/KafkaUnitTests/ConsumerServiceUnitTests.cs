using Confluent.Kafka;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderConfirmationService;

namespace KafkaUnitTests;

[TestClass]
public class ConsumerServiceUnitTests
{
    [TestMethod]
    public async Task StartAsync_SubscribesAndConsumesSingleMessage()
    {
        // Arrange
        var mockConsumer = new Mock<IConsumer<string, string>>();
        var consumerService = new ConsumerService(mockConsumer.Object);
        var cancellationTokenSource = new CancellationTokenSource();

        mockConsumer.Setup(c => c.Consume(It.IsAny<CancellationToken>()))
            .Returns(new ConsumeResult<string, string> { Message = new Message<string, string> { Value = "{\"OrderId\":123}" } })
            .Callback(() => cancellationTokenSource.Cancel());

        // Act
        var task = consumerService.StartAsync(cancellationTokenSource.Token);
        await Task.Delay(100);

        // Assert
        mockConsumer.Verify(c => c.Subscribe("order-events"), Times.Once);
        mockConsumer.Verify(c => c.Consume(It.IsAny<CancellationToken>()), Times.Once);
        await task;
    }
}
