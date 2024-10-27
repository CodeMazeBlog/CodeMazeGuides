using MassTransit;
using NSubstitute;
using MessagingComparisons.Domain;

namespace MessagingComparisons.MassTransit.Tests;

public class MassTransitStrategyTests
{
    [Test]
    public async Task GivenMassTransitMessageBus_WhenSendMessageAsync_ThenPublishIsCalled()
    {
        var message = new Message
        {
            MessageId = Guid.NewGuid().ToString(),
            Content = "Message send using MassTransit"
        };
        var bus = Substitute.For<IBus>();
        var sut = new MassTransitStrategy(bus);
        
        await sut.SendMessageAsync(message);

        await bus.Received(1).Publish(message);
    }
}