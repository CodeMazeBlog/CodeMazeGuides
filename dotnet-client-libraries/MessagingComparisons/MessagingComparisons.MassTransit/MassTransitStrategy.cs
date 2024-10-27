using MassTransit;
using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;

namespace MessagingComparisons.MassTransit;

public class MassTransitStrategy(IBus bus, ISendEndpointProvider sendEndpointProvider) : IMessageBusStrategy
{
    public async Task SendMessageAsync(Message message) => await bus.Publish(message);
    
    public async Task SendMessageAsync(MessageWithQueueName message)
    {
        var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri(message.QueueName));
        
        await sendEndpoint.Send(message);
    }
}