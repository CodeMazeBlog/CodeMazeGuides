using Common.Messaging;
using Common.Models.Messages;
using RabbitMQ.Client;

namespace Microservice.ShoppingCartApi
{
    public class CheckoutItemProducer : ProducerBase<CheckoutItem>
    {
        public CheckoutItemProducer(ConnectionFactory connectionFactory,
                                     ILogger<RabbitMqClientBase> logger,
                                     ILogger<ProducerBase<CheckoutItem>> producerBaseLogger) 
            : base(connectionFactory, logger, producerBaseLogger)
        {
        }
        protected override string QueueName => "stock-validator";
    }       
}