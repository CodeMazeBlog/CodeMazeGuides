using Rebus.Bus;
using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;

namespace MessagingComparisons.Rebus;

public class RebusMessageSender(IBus bus) : IMessageSender
{
    public async Task SendMessageAsync(Message message) => await bus.Send(message);
}
