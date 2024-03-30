using RabbitMQ.Client;

namespace Common.RabbitMq
{
    public interface IRabbitMqConnectionManager
    {
        IModel? Channel { get; set; }
        IConnection? Connection { get; set; }

        void Dispose();
        void InitializeConnection();
    }
}