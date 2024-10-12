using MassTransit;
using MessagingComparisons.Domain;

namespace MessagingComparisons.MassTransit;

public class MessageSender(IBus bus) : IMessageSender
{
    public async Task SendMessageAsync()
    {
        var message = new Message
        {
            MessageId = Guid.NewGuid().ToString(),
            Content = "Message send using MassTransit"
        }; 
        
        await bus.Publish(message);
    }
}