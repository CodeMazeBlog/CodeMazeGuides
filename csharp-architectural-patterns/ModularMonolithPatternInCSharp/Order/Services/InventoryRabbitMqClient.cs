using Common.RabbitMq;
using Inventory.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Order.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Order.Services;

public class InventoryRabbitMqClient(IOptions<RabbitMqConfiguration> rabbitMqConfiguration, IRabbitMqConnectionManager rabbitMqConnectionManager) : IInventoryRabbitMqClient
{
    private readonly RabbitMqConfiguration _rabbitMqConfiguration = rabbitMqConfiguration.Value;
    private readonly IRabbitMqConnectionManager _rabbitMqConnectionManager = rabbitMqConnectionManager;

    public void UpdateQuantity(UpdateQuantityDto updateQuantityDto)
    {

        var serializedMessage = JsonSerializer.Serialize(updateQuantityDto);
        var body = Encoding.UTF8.GetBytes(serializedMessage);

        var queueName = _rabbitMqConfiguration.QueueName;

        _rabbitMqConnectionManager.Channel.BasicPublish(exchange: string.Empty,
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);
    }
}
