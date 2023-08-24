using System.Text;
using Common.Messaging;
using Common.Models.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Microservice.StockValidatorService
{
    public class StockValidationSuccessfulProducer : ProducerBase<CheckoutItem>
    {        
        public StockValidationSuccessfulProducer(ConnectionFactory connectionFactory,
                                                  ILogger<RabbitMqClientBase> logger,
                                                  ILogger<ProducerBase<CheckoutItem>> producerBaseLogger) 
            : base(connectionFactory, logger, producerBaseLogger)
        {
        }

        protected override string QueueName => "stock-validation-successful";
    }
}