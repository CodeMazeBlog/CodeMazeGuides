namespace DifferenceBetweenInAndOutInGenerics.UnitTests;

using Consumers;
using Messages;

public class ConsumerTests
{
    [Fact]
    public void WhenConsumerIsBaseMessageConsumerButDowncastToTestMessageConsumer_ThenTheConsumerIsStillBaseMessage()
    {
        // Arrange
        IConsumer<TestMessage> consumer = new Consumer<BaseMessage>();

        // Act & Assert
        Assert.IsType<Consumer<BaseMessage>>(consumer);
    }
}