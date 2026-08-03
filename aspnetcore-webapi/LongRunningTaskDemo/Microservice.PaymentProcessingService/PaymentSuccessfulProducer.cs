using Common.Messaging;
using Common.Models.Messages;
using RabbitMQ.Client;

namespace Microservice.PaymentProcessingService
{
    public class PaymentSuccessfulProducer : ProducerBase<PaymentSuccess>
    {       
        public PaymentSuccessfulProducer(ConnectionFactory connectionFactory,
                                         ILogger<RabbitMqClientBase> logger,
                                         ILogger<ProducerBase<PaymentSuccess>> producerBaseLogger)
            : base(connectionFactory, logger, producerBaseLogger)
        {
        }

        protected override string QueueName => "payment-successful";
    }
}
