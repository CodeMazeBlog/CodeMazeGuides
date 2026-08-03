namespace DifferenceBetweenInAndOutInGenerics.UnitTests;

using Messages;
using Producers;

public class UnitTest1
{
    [Fact]
    public void WhenProducerIsForTestMessage_ThenMessageTypeShouldBeTestMessage()
    {
        // Arrange
        IProducer<BaseMessage> producer = new Producer<TestMessage>();

        // Act
        var message = producer.Produce();

        // Assert
        Assert.IsType<TestMessage>(message);
    }

    [Fact]
    public void WhenProducerIsTestMessageProducerButUpcastedToBaseMessageProducer_ThenTheProducerIsStillTestMessage()
    {
        // Arrange
        IProducer<BaseMessage> producer;

        // Act
        producer = new Producer<TestMessage>();

        //Assert
        Assert.IsType<Producer<TestMessage>>(producer);
    }
}