using MassTransit;
using MessagingComparisons.Domain;

namespace MessagingComparisons.MassTransit;

public class MessageHandler : IConsumer<Message>
{
    public Task Consume(ConsumeContext<Message> context)
    {
        var message = context.Message;
        Console.WriteLine($"MessageId: {message.MessageId}, Content: {message.Content}");
        
        return Task.CompletedTask;
    }
}