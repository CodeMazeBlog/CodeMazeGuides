using GenerateUniqueIDsWithNewId.Contracts;
using GenerateUniqueIDsWithNewId.Data;
using GenerateUniqueIDsWithNewId.Services;
using GenerateUniqueIDsWithNewId.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddDbContext<OrdersDbContext>(options =>
    options.UseInMemoryDatabase("Orders"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/orders", async (IOrderService service) =>
{
    var orders = await service.GetAllAsync();

    return Results.Ok(orders);
})
.WithOpenApi();

app.MapGet("/orders/{id:guid}", async (Guid id, IOrderService service) =>
{
    var order = await service.GetByIdAsync(id);

    return Results.Ok(order);
})
.WithOpenApi();

app.MapPost("/orders", async (OrderForCreationDto dto, IOrderService service) =>
{
    var order = await service.CreateAsync(dto);

    return Results.Created($"/orders/{order.Id}", order);
})
.WithOpenApi();

app.MapPut("/orders/{id:guid}", async (Guid id, OrderForUpdateDto dto, IOrderService service) =>
{
    await service.UpdateAsync(id, dto);

    return Results.NoContent();
})
.WithOpenApi();

app.MapDelete("/orders/{id:guid}", async (Guid id, IOrderService service) =>
{
    await service.DeleteAsync(id);

    return Results.NoContent();
})
.WithOpenApi();

app.Run();

public partial class Program { }
