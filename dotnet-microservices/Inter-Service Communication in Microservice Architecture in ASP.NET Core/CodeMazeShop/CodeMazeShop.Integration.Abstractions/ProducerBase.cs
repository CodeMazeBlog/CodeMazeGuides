using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace CodeMazeShop.Integration.Abstractions;

public class ProducerBase<T> : RabbitMqClientBase, IMessageProducer<T>
{
    private readonly ILogger<ProducerBase<T>> _logger;

    protected ProducerBase(ConnectionFactory connectionFactory,
                            ILogger<RabbitMqClientBase> logger,
                            ILogger<ProducerBase<T>> producerBaseLogger,
                            string queueName) : base(connectionFactory, logger, queueName)
    {
        _logger = producerBaseLogger;
    }

    public virtual Task SendMessage(T message)
    {
        try
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
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

        return Task.CompletedTask;
    }
}
