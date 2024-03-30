using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Common.RabbitMq;

internal class RabbitMqConnectionManager(IConfiguration configuration) : IDisposable, IRabbitMqConnectionManager
{
    private readonly IConfiguration _configuration = configuration;

    public IConnection? Connection { get; set; }
    public IModel? Channel { get; set; }

    public void InitializeConnection()
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = _configuration["RabbitMq:HostName"],
            Port = _configuration.GetValue<int>("RabbitMq:Port"),
            UserName = _configuration["RabbitMq:UserName"],
            Password = _configuration["RabbitMq:Password"]
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
