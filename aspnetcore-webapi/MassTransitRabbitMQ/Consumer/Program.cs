using MassTransit;
using Microsoft.Extensions.Hosting;
using SharedModels;
using System.Text.Json;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderCreatedConsumer>()
        .Endpoint(e => e.Name = "order-created-event");

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

await builder.Build().RunAsync();

class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    public Task Consume(ConsumeContext<OrderCreated> context)
    {
        var jsonMessage = JsonSerializer.Serialize(context.Message);
        Console.WriteLine($"OrderCreated message: {jsonMessage}");

        return Task.CompletedTask;
    }
}
