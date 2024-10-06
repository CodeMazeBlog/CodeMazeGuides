using Rebus.Bus;
using RebusVsNServiceBusVsMassTransit.Domain;

namespace RebusVsNServiceBusVsMassTransit.Rebus;

public interface IMessageSender
{
    Task SendMessageAsync();
}

public class MessageSender(IBus bus) : IMessageSender
{
    public async Task SendMessageAsync()
    {
        var message = new ProcessPayment()
        {
            TransactionId = Guid.NewGuid().ToString(),
            CreditCardNumber = "4242 4242 4242 4242"
        }; 
        
        await bus.Send(message);
    }
}