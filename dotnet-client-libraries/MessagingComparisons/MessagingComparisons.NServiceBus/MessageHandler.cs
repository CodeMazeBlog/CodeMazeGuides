using MessagingComparisons.Domain;

namespace MessagingComparisons.NServiceBus;

public class MessageHandler : IHandleMessages<Message>
{
    public Task Handle(Message message, IMessageHandlerContext context)
    {
        Console.WriteLine($"MessageId: {message.MessageId}, Content: {message.Content}");
        
        return Task.CompletedTask;
    }
}