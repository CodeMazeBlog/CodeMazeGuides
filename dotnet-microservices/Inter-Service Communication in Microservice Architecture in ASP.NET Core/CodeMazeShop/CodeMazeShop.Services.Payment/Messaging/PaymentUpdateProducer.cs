using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using RabbitMQ.Client;

namespace CodeMazeShop.Services.Payment.Messaging;

public class PaymentUpdateProducer : ProducerBase<PaymentUpdateMessage>
{
    public PaymentUpdateProducer(ConnectionFactory connectionFactory,
                             IConfiguration configuration,
                             ILogger<RabbitMqClientBase> logger,
                             ILogger<ProducerBase<PaymentUpdateMessage>> producerBaseLogger)
    : base(connectionFactory, logger, producerBaseLogger, configuration["RabbitMQ:PaymentUpdateQueueName"])
    {
        
    }    
}
