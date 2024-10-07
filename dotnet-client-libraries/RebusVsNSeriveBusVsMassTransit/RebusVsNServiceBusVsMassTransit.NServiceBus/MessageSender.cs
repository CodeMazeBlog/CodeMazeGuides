using RebusVsNServiceBusVsMassTransit.Domain;

namespace RebusVsNServiceBusVsMassTransit.NServiceBus;

public class MessageSender(IMessageSession messageSession) : IMessageSender
{
    public async Task SendMessageAsync()
    {
        var message = new Message
        {
            MessageId = Guid.NewGuid().ToString(),
            Content = "Message send using NServiceBus"
        }; 
        
        await messageSession.Send(message);
    }
}