using MassTransit;
using RebusVsNServiceBusVsMassTransit.Domain;

namespace RebusVsNServiceBusVsMassTransit.MassTransit;

public class MessageHandler : IConsumer<ProcessPayment>
{
    public Task Consume(ConsumeContext<ProcessPayment> context)
    {
        var message = context.Message;
        Console.WriteLine($"MassTransit received message for TransactionId: {message.TransactionId}"); 
        
        return Task.CompletedTask;
    }
}