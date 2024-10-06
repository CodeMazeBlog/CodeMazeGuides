using RebusVsNServiceBusVsMassTransit.Domain;

namespace RebusVsNServiceBusVsMassTransit.NServiceBus;

public class MessageHandler : IHandleMessages<ProcessPayment>
{
    public Task Handle(ProcessPayment message, IMessageHandlerContext context)
    {
        Console.WriteLine($"NServiceBus received message for TransactionId: {message.TransactionId}"); 
        
        return Task.CompletedTask;
    }
}