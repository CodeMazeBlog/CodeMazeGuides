#nullable disable
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Producer.RabbitMQ
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            // Start here for publisher
        }
    }
}
