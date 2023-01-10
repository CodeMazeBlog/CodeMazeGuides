using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using RabbitMQ.Client;

namespace CodeMazeShop.Services.ShoppingCart.Messaging;

public class CheckoutProducer : ProducerBase<CartCheckoutMessage>
{    
    public CheckoutProducer(ConnectionFactory connectionFactory,
                            IConfiguration configuration,
                            ILogger<RabbitMqClientBase> logger,
                            ILogger<ProducerBase<CartCheckoutMessage>> producerBaseLogger)
    : base(connectionFactory, 
           logger, 
           producerBaseLogger, 
           configuration["RabbitMQ:CheckoutQueueName"])
    {
        
    }    
}