using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;

namespace MessagingComparisons.NServiceBus;

public class NServiceBusMessageSender(IMessageSession messageSession) : IMessageSender
{
    public async Task SendMessageAsync(Message message) => await messageSession.Send(message);
}
