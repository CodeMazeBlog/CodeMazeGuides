using NSubstitute;
using Rebus.Bus;
using RebusVsNServiceBusVsMassTransit.Domain;

namespace RebusVsNServiceBusVsMassTransit.Rebus.Tests;

public class MessageSenderTests
{
    [Test]
    public async Task GivenRebusMessageBus_WhenSendMessageAsync_ThenSendIsCalled()
    {
        var bus = Substitute.For<IBus>();
        var sut = new MessageSender(bus);
        
        await sut.SendMessageAsync();

        await bus.Received(1).Send(Arg.Any<Message>());
    }
}