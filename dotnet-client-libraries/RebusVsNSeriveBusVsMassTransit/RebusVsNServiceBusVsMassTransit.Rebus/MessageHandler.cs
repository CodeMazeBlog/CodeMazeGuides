using Rebus.Handlers;
using RebusVsNServiceBusVsMassTransit.Domain;

namespace RebusVsNServiceBusVsMassTransit.Rebus;

public class MessageHandler : IHandleMessages<Message>
{
    public Task Handle(Message message)
    {
        Console.WriteLine($"MessageId: {message.MessageId}, Content: {message.Content}"); 
        
        return Task.CompletedTask;
    }
}