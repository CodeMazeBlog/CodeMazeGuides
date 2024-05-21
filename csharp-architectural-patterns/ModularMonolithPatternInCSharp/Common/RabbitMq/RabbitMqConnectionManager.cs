using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Common.RabbitMq;

internal class RabbitMqConnectionManager(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
    : IDisposable, IRabbitMqConnectionManager
{
    public IConnection? Connection { get; private set; }
    public IModel? Channel { get; private set; }

    public void InitializeConnection()
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = rabbitMqConfiguration.Value.HostName,
            Port = rabbitMqConfiguration.Value.Port,
            UserName = rabbitMqConfiguration.Value.UserName,
            Password = rabbitMqConfiguration.Value.Password
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
