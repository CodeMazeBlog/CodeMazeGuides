using NSubstitute;
using Rebus.Bus;
using MessagingComparisons.Domain;

namespace MessagingComparisons.Rebus.Tests;

public class RebusMessageSenderTests
{
    [Test]
    public async Task GivenRebusMessageBus_WhenSendMessageAsync_ThenSendIsCalled()
    {
        var message = new Message
        {
            MessageId = Guid.NewGuid().ToString(),
            Content = "Message send using Rebus"
        };
        var bus = Substitute.For<IBus>();
        var sut = new RebusMessageSender(bus);
        
        await sut.SendMessageAsync(message);

        await bus.Received(1).Send(message);
    }
}