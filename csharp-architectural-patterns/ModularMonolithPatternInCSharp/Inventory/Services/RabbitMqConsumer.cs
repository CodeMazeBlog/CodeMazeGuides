using Inventory.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Inventory.Services;

internal class RabbitMqConsumer(IServiceScopeFactory scopeFactory, IConfiguration configuration) : IRabbitMqConsumer
{   
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
    private readonly IConfiguration _configuration = configuration;

    public void Consume()
    {
        // initialize connection

        var connectionFactory = new ConnectionFactory
        {
            HostName = _configuration["RabbitMq:HostName"],
            Port = _configuration.GetValue<int>("RabbitMq:Port"),
            UserName = _configuration["RabbitMq:UserName"],
            Password = _configuration["RabbitMq:Password"]
        };

        var connection = connectionFactory.CreateConnection();
        var channel = connection.CreateModel();

        // declare queue
        var queueName = _configuration["RabbitMq:QueueName"];
        channel.QueueDeclare(queueName, true, true, false);

        // start consuming from queue

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var updateQuantityDto = JsonSerializer.Deserialize<UpdateQuantityDto>(message);

            if (updateQuantityDto is null)
                return;

            HandleEventAsync(updateQuantityDto);
        };

        channel.BasicConsume(
            queue: queueName, 
            autoAck: true,
            consumer: consumer);
    }

    private void HandleEventAsync(UpdateQuantityDto updateQuantityDto)
    {
        var scope = _scopeFactory.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<IItemService>();

        service.UpdateQuantity(updateQuantityDto);
    }
}

public interface IRabbitMqConsumer
{
    void Consume();
}