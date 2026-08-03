using OnionArchitecture.PizzaStore.Domain.Repositories;
using OnionArchitecture.PizzaStore.Persistence.Repositories;
using OnionArchitecture.PizzaStore.Services;
using OnionArchitecture.PizzaStore.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();