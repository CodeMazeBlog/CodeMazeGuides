using MassTransit;
using MessagingComparisons.Domain;

namespace MessagingComparisons.MassTransit;

public class MassTransitStrategy(IBus bus) : IMessageBusStrategy
{
    public async Task SendMessageAsync(Message message)
    {
        await bus.Publish(message);
    }
}