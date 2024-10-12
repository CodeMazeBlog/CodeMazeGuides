using NSubstitute;
using MessagingComparisons.Domain;

namespace MessagingComparisons.NServiceBus.Tests;

public class MessageSenderTests
{
    [Test]
    public async Task GivenNServiceBusMessageBus_WhenSendMessageAsync_ThenSendIsCalled()
    {
        var messageSession = Substitute.For<IMessageSession>();
        var sut = new MessageSender(messageSession);
        
        await sut.SendMessageAsync();

        await messageSession.Received(1).Send(Arg.Any<object>(), Arg.Any<SendOptions>());
    }
}