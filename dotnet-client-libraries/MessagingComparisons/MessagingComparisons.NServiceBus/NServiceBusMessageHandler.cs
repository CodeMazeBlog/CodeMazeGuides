using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;

namespace MessagingComparisons.NServiceBus;

public class NServiceBusMessageHandler(IMessageHandler handler) : IHandleMessages<Message>
{
    public Task Handle(Message message, IMessageHandlerContext context) => handler.Handle(message);
}