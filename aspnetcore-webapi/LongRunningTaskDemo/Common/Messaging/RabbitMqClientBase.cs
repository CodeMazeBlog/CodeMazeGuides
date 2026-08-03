using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Common.Messaging
{
    public abstract class RabbitMqClientBase : IDisposable
    {       
        protected abstract string QueueName { get; }
        protected IModel Channel { get; private set; }
        private IConnection _connection;
        private readonly ConnectionFactory _connectionFactory;
        private readonly ILogger<RabbitMqClientBase> _logger;

        protected RabbitMqClientBase(ConnectionFactory connectionFactory, 
                                     ILogger<RabbitMqClientBase> logger)
        {
            _connectionFactory = connectionFactory;
            _logger = logger;
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
}
