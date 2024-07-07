using Rebus.Bus;
using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using RebusSagaPattern.Models;
using RebusSagaPattern.Repositories;
using RebusSagaPattern.Sagas.Messages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

builder.Services.AddRebus(configure => configure
    .Routing(routing => routing.TypeBased().MapAssemblyOf<Program>("Rebus.OrderQueue"))
    .Transport(transport => 
        transport.UseRabbitMq(
            builder.Configuration.GetConnectionString("RabbitMq"),
            "Rebus.OrderQueue"))
    .Sagas(saga => saga.StoreInMemory())
);

builder.Services.AutoRegisterHandlersFromAssemblyOf<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/orders/{orderId}", async (IOrderRepository orderRepository, string orderId) =>
    {
        var validGuid = Guid.TryParse(orderId, out var orderGuid);

        if (validGuid)
        {
            var order = await orderRepository.GetOrderById(orderGuid);

            return Results.Ok(order);
        }

        return Results.NotFound();
    })
    .WithName("GetOrder");

app.MapPost("/api/orders", async (IOrderRepository orderRepository, IBus bus, CreateOrderRequest request) =>
    {
        var order = new Order
        {
            OrderId = Guid.NewGuid()
        };
        await orderRepository.AddOrder(order);
        
        await bus.Send(new OrderPlacedEvent
        {
            OrderId = order.OrderId
        });

        return Results.CreatedAtRoute("GetOrder", new { order.OrderId });
    })
    .WithName("CreateOrder");

app.MapPost("/api/orders/{orderId}/payment", async (IOrderRepository orderRepository, IBus bus, string orderId) =>
    {
        var validGuid = Guid.TryParse(orderId, out var orderGuid);

        if (validGuid)
        {
            var order = await orderRepository.GetOrderById(orderGuid);
            
            await bus.Send(new PaymentProcessedEvent
            {
                OrderId = order.OrderId
            });

            return Results.Accepted();
        }

        return Results.NotFound();
    })
    .WithName("CreatePayment");

app.Run();