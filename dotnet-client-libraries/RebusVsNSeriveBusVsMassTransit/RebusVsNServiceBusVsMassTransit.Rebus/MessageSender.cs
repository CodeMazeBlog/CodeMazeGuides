using Rebus.Bus;
using RebusVsNServiceBusVsMassTransit.Domain;

namespace RebusVsNServiceBusVsMassTransit.Rebus;

public class MessageSender(IBus bus) : IMessageSender
{
    public async Task SendMessageAsync()
    {
        var message = new Message
        {
            MessageId = Guid.NewGuid().ToString(),
            Content = "Message send using Rebus"
        }; 
        
        await bus.Send(message);
    }
}