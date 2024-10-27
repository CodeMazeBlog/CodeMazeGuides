using MessagingComparisons.Domain;

namespace MessagingComparisons.NServiceBus;

public class NServiceBusStrategy(IMessageSession messageSession) : IMessageBusStrategy
{
    public async Task SendMessageAsync(Message message)
    {
        await messageSession.Send(message);
    }
}