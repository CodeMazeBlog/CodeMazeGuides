using Common.Messaging;
using Common.Models.Messages;
using RabbitMQ.Client;

namespace Microservice.TaxCalculatorService
{
    public class TaxProducer : ProducerBase<Tax>
    {
        public TaxProducer(ConnectionFactory connectionFactory, 
                            ILogger<RabbitMqClientBase> logger, 
                            ILogger<ProducerBase<Tax>> producerBaseLogger) 
            : base(connectionFactory, logger, producerBaseLogger)
        {
        }

        protected override string QueueName => "tax";       
    }
}