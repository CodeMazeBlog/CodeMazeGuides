using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Common.Messaging
{
    public abstract class ProducerBase<T> : RabbitMqClientBase, IMessageProducer<T>
    {
        private readonly ILogger<ProducerBase<T>> _logger;

        protected ProducerBase(ConnectionFactory connectionFactory,
                                ILogger<RabbitMqClientBase> logger,
                                ILogger<ProducerBase<T>> producerBaseLogger) : base(connectionFactory, logger)
        {
            _logger = producerBaseLogger;
        }

        public virtual void SendMessage(T message)
        {
            try
            {
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                var properties = Channel.CreateBasicProperties();                
                properties.ContentType = "application/json";
                properties.DeliveryMode = 1; // Doesn't persist to disk
                properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                Channel.BasicPublish(exchange: "", routingKey: QueueName, body: body, basicProperties: properties);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error while publishing");
            }
        }
    }
}