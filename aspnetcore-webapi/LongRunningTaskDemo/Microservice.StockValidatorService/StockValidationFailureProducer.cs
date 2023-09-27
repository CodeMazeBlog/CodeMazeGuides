using Common.Messaging;
using Common.Models.Messages;
using RabbitMQ.Client;

namespace Microservice.StockValidatorService
{
    public class StockValidationFailureProducer : ProducerBase<Failure>
    {
        public StockValidationFailureProducer(ConnectionFactory connectionFactory, 
                                               ILogger<RabbitMqClientBase> logger, 
                                               ILogger<ProducerBase<Failure>> producerBaseLogger)
            : base(connectionFactory, logger, producerBaseLogger)
        {
        }

        protected override string QueueName => "stock-validation-failure";
    }
}
