using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace CodeMazeShop.Integration.Abstractions;

public class RabbitMqClientBase : IDisposable
{
    protected string QueueName { get; }

    protected IModel Channel { get; private set; }

    private IConnection _connection;

    private readonly ConnectionFactory _connectionFactory;

    private readonly ILogger<RabbitMqClientBase> _logger;

    public RabbitMqClientBase(ConnectionFactory connectionFactory, ILogger<RabbitMqClientBase> logger, string queueName)
    {
        _connectionFactory = connectionFactory;
        _logger = logger;
        QueueName = queueName;
        Connect();
    }

    private void Connect()
    {
        if (_connection == null || _connection.IsOpen == false)
        {
            _connection = _connectionFactory.CreateConnection();
        }

        if (Channel == null || Channel.IsOpen == false)
        {
            Channel = _connection.CreateModel();
            Channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false);
        }
    }

    public void Dispose()
    {
        try
        {
            Channel?.Close();
            Channel?.Dispose();
            Channel = null;

            _connection?.Close();
            _connection?.Dispose();
            _connection = null;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Cannot dispose RabbitMQ channel or connection");
        }
    }
}
