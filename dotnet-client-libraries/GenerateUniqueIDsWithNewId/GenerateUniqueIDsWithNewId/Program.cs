using GenerateUniqueIDsWithNewId.Contracts;
using GenerateUniqueIDsWithNewId.Data;
using GenerateUniqueIDsWithNewId.Services;
using GenerateUniqueIDsWithNewId.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddDbContext<OrdersDbContext>(options =>
    options.UseInMemoryDatabase("Orders"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/orders", async (IOrderService service) =>
{
    var orders = await service.GetAllAsync();

    return Results.Ok(orders);
});

app.MapGet("/orders/{id:guid}", async (Guid id, IOrderService service) =>
{
    var order = await service.GetByIdAsync(id);

    return Results.Ok(order);
});

app.MapPost("/orders", async (OrderForCreationDto dto, IOrderService service) =>
{
    var order = await service.CreateAsync(dto);

    return Results.Created($"/orders/{order.Id}", order);
});

app.MapPut("/orders/{id:guid}", async (Guid id, OrderForUpdateDto dto, IOrderService service) =>
{
    await service.UpdateAsync(id, dto);

    return Results.NoContent();
});

app.MapDelete("/orders/{id:guid}", async (Guid id, IOrderService service) =>
{
    await service.DeleteAsync(id);

    return Results.NoContent();
});

app.Run();

public partial class Program { }
