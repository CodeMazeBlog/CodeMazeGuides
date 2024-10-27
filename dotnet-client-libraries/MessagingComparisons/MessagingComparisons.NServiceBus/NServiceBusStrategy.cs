using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;

namespace MessagingComparisons.NServiceBus;

public class NServiceBusStrategy(IMessageSession messageSession) : IMessageBusStrategy
{
    public async Task SendMessageAsync(Message message)
    {
        await messageSession.Send(message);
    }
}