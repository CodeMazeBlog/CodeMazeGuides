using MassTransit;
using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;

namespace MessagingComparisons.MassTransit;

public class MassTransitStrategy(IBus bus) : IMessageBusStrategy
{
    public async Task SendMessageAsync(Message message)
    {
        await bus.Publish(message);
    }
}