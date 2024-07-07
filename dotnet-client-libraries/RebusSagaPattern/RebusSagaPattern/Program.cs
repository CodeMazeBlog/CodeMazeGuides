using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using RebusSagaPattern.Models;
using RebusSagaPattern.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderRepository, OrderRepository>();

builder.Services.AddRebus(configure => configure
    .Transport(transport => 
        transport.UseRabbitMq(
            builder.Configuration.GetConnectionString("RabbitMq"),
            "Rebus.OrderQueue"))
    .Routing(routing => routing.TypeBased().MapAssemblyOf<Program>("Rebus.OrderQueue"))
    .Sagas(saga => saga.StoreInMemory())
    .Timeouts(timeout => timeout.StoreInMemory())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/orders/{orderId}", async (IOrderRepository orderRepository, string orderId) =>
    {
        var validGuid = Guid.TryParse(orderId, out var orderGuid);

        if (validGuid) 
        {
            var order = await orderRepository.GetOrderById(orderGuid);

            return Results.Ok(order);
        }

        return Results.NotFound();
    })
    .WithName("GetOrder")
    .WithOpenApi();

app.MapPost("/orders", async (IOrderRepository orderRepository, CreateOrderRequest request) =>
    {
        var order = new Order
        {
            OrderId = Guid.NewGuid()
        };
        
        await orderRepository.AddOrder(order);
        
        return Results.CreatedAtRoute("GetOrder", new { order.OrderId });
    })
    .WithName("PostOrder")
    .WithOpenApi();

app.MapPost("/orders/{orderId}/payment", async (IOrderRepository orderRepository, string orderId) =>
    {
        var validGuid = Guid.TryParse(orderId, out var orderGuid);

        if (validGuid) 
        {
            var order = await orderRepository.GetOrderById(orderGuid);

            return Results.Accepted();
        }

        return Results.NotFound();
    })
    .WithName("PostPayment")
    .WithOpenApi();

app.Run();