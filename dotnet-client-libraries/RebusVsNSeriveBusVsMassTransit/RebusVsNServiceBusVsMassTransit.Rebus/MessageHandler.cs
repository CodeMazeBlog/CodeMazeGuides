using Rebus.Handlers;
using RebusVsNServiceBusVsMassTransit.Domain;

namespace RebusVsNServiceBusVsMassTransit.Rebus;

public class MessageHandler : IHandleMessages<ProcessPayment>
{
    public Task Handle(ProcessPayment message)
    {
        Console.WriteLine($"Rebus received message for TransactionId: {message.TransactionId}"); 
        
        return Task.CompletedTask;
    }
}