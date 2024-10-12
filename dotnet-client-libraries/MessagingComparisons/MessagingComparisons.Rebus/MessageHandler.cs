using Rebus.Handlers;
using MessagingComparisons.Domain;

namespace MessagingComparisons.Rebus;

public class MessageHandler : IHandleMessages<Message>
{
    public Task Handle(Message message)
    {
        Console.WriteLine($"MessageId: {message.MessageId}, Content: {message.Content}"); 
        
        return Task.CompletedTask;
    }
}