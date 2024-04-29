using Common.RabbitMq;
using Inventory.Interfaces;
using Inventory.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Inventory.Services;

internal class RabbitMqConsumer(
    IServiceScopeFactory scopeFactory,
    IOptions<RabbitMqConfiguration> rabbitMqConfiguration,
    IRabbitMqConnectionManager rabbitMqConnectionManager) : IRabbitMqConsumer
{
    public void Consume()
    {
        var queueName = rabbitMqConfiguration.Value.QueueName;
        rabbitMqConnectionManager.Channel.QueueDeclare(
            queue: queueName,
            durable: true,
            exclusive: true,
            autoDelete: false);

        var consumer = new EventingBasicConsumer(rabbitMqConnectionManager.Channel);

        consumer.Received += HandleEventAsync;

        rabbitMqConnectionManager.Channel.BasicConsume(
            queue: queueName,
            autoAck: true,
            consumer: consumer);
    }

    private void HandleEventAsync(object? model, BasicDeliverEventArgs ea)
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        var updateQuantityDto = JsonSerializer.Deserialize<UpdateQuantityDto>(message);

        if (updateQuantityDto is null)
            return;

        UpdateItemQuantity(updateQuantityDto);
    }

    private void UpdateItemQuantity(UpdateQuantityDto updateQuantityDto)
    {
        var scope = scopeFactory.CreateScope();
        var itemService = scope.ServiceProvider.GetRequiredService<IItemService>();

        itemService.UpdateQuantity(updateQuantityDto);
    }
}