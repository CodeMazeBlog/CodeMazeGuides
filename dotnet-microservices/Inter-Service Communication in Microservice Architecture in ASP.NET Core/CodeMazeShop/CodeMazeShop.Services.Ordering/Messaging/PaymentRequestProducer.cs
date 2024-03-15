using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using RabbitMQ.Client;

namespace CodeMazeShop.Services.Ordering.Messaging;

public class PaymentRequestProducer : ProducerBase<PaymentRequestMessage>
{
    public PaymentRequestProducer(ConnectionFactory connectionFactory,
                                  IConfiguration configuration,
                                  ILogger<RabbitMqClientBase> logger,
                                  ILogger<ProducerBase<PaymentRequestMessage>> producerBaseLogger)
    : base(connectionFactory, logger, producerBaseLogger, configuration["RabbitMQ:PaymentRequestQueueName"])
    {
       
    }    
}

