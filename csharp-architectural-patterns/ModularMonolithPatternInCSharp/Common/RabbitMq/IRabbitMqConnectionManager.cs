using RabbitMQ.Client;

namespace Common.RabbitMq;

public interface IRabbitMqConnectionManager
{
    IModel? Channel { get; }
    IConnection? Connection { get; }

    void InitializeConnection();
}