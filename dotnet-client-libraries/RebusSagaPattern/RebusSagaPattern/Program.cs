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

app.MapGet("/api/orders/{orderId}", (IOrderRepository orderRepository, string orderId) =>
    {
        if (Guid.TryParse(orderId, out var orderGuid))
        {
            var order = orderRepository.GetOrderById(orderGuid);

            return Results.Ok(order);
        }

        return Results.NotFound();
    })
    .WithName("GetOrder");

app.MapPost("/api/orders", async (IOrderRepository orderRepository, IBus bus) =>
    {
        var orderId = Guid.NewGuid();
        await bus.Send(new PlaceOrderCommand
        {
            OrderId = orderId
        });

        return Results.CreatedAtRoute("GetOrder", new { orderId });
    })
    .WithName("CreateOrder");

app.MapPost("/api/orders/{orderId}/payment", async (IOrderRepository orderRepository, IBus bus, string orderId) =>
    {
        if (Guid.TryParse(orderId, out var orderGuid))
        {
            var order = orderRepository.GetOrderById(orderGuid);
            
            await bus.Send(new ProcessPaymentCommand
            {
                OrderId = order.OrderId
            });

            return Results.Accepted();
        }

        return Results.NotFound();
    })
    .WithName("CreatePayment");

app.Run();