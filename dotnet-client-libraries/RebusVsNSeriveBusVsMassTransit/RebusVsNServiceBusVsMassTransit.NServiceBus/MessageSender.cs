using RebusVsNServiceBusVsMassTransit.Domain;

namespace RebusVsNServiceBusVsMassTransit.NServiceBus;

public interface IMessageSender
{
    Task SendMessageAsync();
}

public class MessageSender(IMessageSession messageSession) : IMessageSender
{
    public async Task SendMessageAsync()
    {
        var message = new ProcessPayment()
        {
            TransactionId = Guid.NewGuid().ToString(),
            CreditCardNumber = "4242 4242 4242 4242"
        }; 
        
        await messageSession.Send(message);
    }
}