using MessagingComparisons.Domain.Interfaces;

namespace MessagingComparisons.Domain;

public class MessageHandler : IMessageHandler
{
    public Task Handle(Message message)
    {
        Console.WriteLine($"MessageId: {message.MessageId}, Content: {message.Content}");
        
        return Task.CompletedTask;
    }
}