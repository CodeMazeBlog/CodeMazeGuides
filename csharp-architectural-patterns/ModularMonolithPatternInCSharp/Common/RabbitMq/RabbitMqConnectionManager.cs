using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Common.RabbitMq;

internal class RabbitMqConnectionManager(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
    : IDisposable, IRabbitMqConnectionManager
{
    private readonly RabbitMqConfiguration _rabbitMqConfiguration = rabbitMqConfiguration.Value;

    public IConnection? Connection { get; private set; }
    public IModel? Channel { get; private set; }

    public void InitializeConnection()
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = _rabbitMqConfiguration.HostName,
            Port = _rabbitMqConfiguration.Port,
            UserName = _rabbitMqConfiguration.UserName,
            Password = _rabbitMqConfiguration.Password
        };
        Connection = connectionFactory.CreateConnection();
        Channel = Connection.CreateModel();
    }

    public void Dispose()
    {
        Channel?.Close();
        Connection?.Close();
    }
}
