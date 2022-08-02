using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Common.Messaging
{
    public abstract class ConsumerBase : RabbitMqClientBase
    { 
        protected ConsumerBase(ConnectionFactory connectionFactory,
                               ILogger<RabbitMqClientBase> logger,
                               ILogger<ConsumerBase> consumerLogger) 
            : base(connectionFactory, logger)
        {            
          
            try
            {
                var consumer = new AsyncEventingBasicConsumer(Channel);
                consumer.Received += OnMessageReceived;
                Channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);
            }
            catch (Exception ex)
            {
                consumerLogger.LogCritical(ex, "Error while consuming message");
            }
        }

        protected abstract Task OnMessageReceived(object sender, BasicDeliverEventArgs @event);       

    }
}
