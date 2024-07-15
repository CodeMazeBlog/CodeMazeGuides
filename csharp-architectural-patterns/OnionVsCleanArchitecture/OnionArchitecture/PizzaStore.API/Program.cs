using PizzaStore.API.Middleware;
using PizzaStore.Domain.Repositories;
using PizzaStore.Persistence.Repositories;
using PizzaStore.Services;
using PizzaStore.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.Run();