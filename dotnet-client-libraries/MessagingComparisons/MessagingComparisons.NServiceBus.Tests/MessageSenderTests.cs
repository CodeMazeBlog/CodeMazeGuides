using NSubstitute;
using MessagingComparisons.Domain;

namespace MessagingComparisons.NServiceBus.Tests;

public class MessageSenderTests
{
    [Test]
    public async Task GivenNServiceBusMessageBus_WhenSendMessageAsync_ThenSendIsCalled()
    {
        var message = new Message
        {
            MessageId = Guid.NewGuid().ToString(),
            Content = "Message send using NServiceBus"
        };
        var messageSession = Substitute.For<IMessageSession>();
        var sut = new NServiceBusStrategy(messageSession);
        
        await sut.SendMessageAsync(message);

        await messageSession.Received(1).Send(message, Arg.Any<SendOptions>());
    }
}