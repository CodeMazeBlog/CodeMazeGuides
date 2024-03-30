using Inventory.Models;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Order.Services;

public class InventoryRabbitMqClient(IConfiguration configuration) : IInventoryRabbitMqClient
{
    private readonly IConfiguration _configuration = configuration;

    public void UpdateQuantity(UpdateQuantityDto updateQuantityDto)
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = _configuration["RabbitMq:HostName"],
            Port = _configuration.GetValue<int>("RabbitMq:Port"),
            UserName = _configuration["RabbitMq:UserName"],
            Password = _configuration["RabbitMq:Password"]
        };

        var connection = connectionFactory.CreateConnection();
        var channel = connection.CreateModel();

        var serializedMessage = JsonSerializer.Serialize(updateQuantityDto);
        var body = Encoding.UTF8.GetBytes(serializedMessage);

        var queueName = _configuration["RabbitMq:QueueName"];

        channel.BasicPublish(exchange: string.Empty,
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);
    }
}

public interface IInventoryRabbitMqClient
{
    void UpdateQuantity(UpdateQuantityDto updateQuantityDto);
}
