using Common.Messaging;
using Common.Models.Messages;
using RabbitMQ.Client;

namespace Microservice.PaymentProcessingService
{
    public class PaymentFailureProducer : ProducerBase<Failure>
    {
        public PaymentFailureProducer(ConnectionFactory connectionFactory,
                                      ILogger<RabbitMqClientBase> logger,
                                      ILogger<ProducerBase<Failure>> producerBaseLogger)
            : base(connectionFactory, logger, producerBaseLogger)
        {
        }

        protected override string QueueName => "payment-failure";
    }
}
