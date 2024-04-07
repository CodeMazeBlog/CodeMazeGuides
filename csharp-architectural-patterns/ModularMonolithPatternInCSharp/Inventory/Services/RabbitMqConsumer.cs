using Common.RabbitMq;
using Inventory.Interfaces;
using Inventory.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Inventory.Services;

internal class RabbitMqConsumer(
    IServiceScopeFactory scopeFactory, 
    IConfiguration configuration, 
    IRabbitMqConnectionManager rabbitMqConnectionManager) : IRabbitMqConsumer
{   
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
    private readonly IConfiguration _configuration = configuration;
    private readonly IRabbitMqConnectionManager _rabbitMqConnectionManager = rabbitMqConnectionManager;

    public void Consume()
    {
        var queueName = _configuration["RabbitMq:QueueName"];
        _rabbitMqConnectionManager.Channel.QueueDeclare(
            queue: queueName,
            durable: true,
            exclusive: true,
            autoDelete: false);

        var consumer = new EventingBasicConsumer(_rabbitMqConnectionManager.Channel);

        consumer.Received += HandleEventAsync;

        _rabbitMqConnectionManager.Channel.BasicConsume(
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
        var scope = _scopeFactory.CreateScope();
        var itemService = scope.ServiceProvider.GetRequiredService<IItemService>();

        itemService.UpdateQuantity(updateQuantityDto);
    }
}