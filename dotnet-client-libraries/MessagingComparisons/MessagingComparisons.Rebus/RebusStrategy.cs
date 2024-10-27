using Rebus.Bus;
using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;

namespace MessagingComparisons.Rebus;

public class RebusStrategy(IBus bus) : IMessageBusStrategy
{
    public async Task SendMessageAsync(Message message) => await bus.Send(message);
}