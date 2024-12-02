using MassTransit;
using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;

namespace MessagingComparisons.MassTransit;

public class MassTransitMessageHandler(IMessageHandler handler) : IConsumer<Message>
{
    public Task Consume(ConsumeContext<Message> context)
    {
        var message = context.Message;

        return handler.Handle(message);
    }
}