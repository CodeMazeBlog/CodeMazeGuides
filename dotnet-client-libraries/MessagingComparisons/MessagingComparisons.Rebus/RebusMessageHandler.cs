using Rebus.Handlers;
using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;

namespace MessagingComparisons.Rebus;

public class RebusMessageHandler(IMessageHandler handler) : IHandleMessages<Message>
{
    public Task Handle(Message message) => handler.Handle(message);
}