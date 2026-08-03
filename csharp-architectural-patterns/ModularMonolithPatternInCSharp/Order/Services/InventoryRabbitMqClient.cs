using Common.RabbitMq;
using Inventory.Models;
using Microsoft.Extensions.Options;
using Order.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Order.Services;

internal class InventoryRabbitMqClient(IOptions<RabbitMqConfiguration> rabbitMqConfiguration, IRabbitMqConnectionManager rabbitMqConnectionManager) : IInventoryRabbitMqClient
{
    public void UpdateQuantity(UpdateQuantityDto updateQuantityDto)
    {
        var serializedMessage = JsonSerializer.Serialize(updateQuantityDto);
        var body = Encoding.UTF8.GetBytes(serializedMessage);

        var queueName = rabbitMqConfiguration.Value.QueueName;

        rabbitMqConnectionManager.Channel.BasicPublish(exchange: string.Empty,
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);
    }
}
