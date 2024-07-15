using PizzaStore.Application;
using PizzaStore.Domain.Repositories;
using PizzaStore.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationDependencies();
builder.Services.AddSingleton<IPizzaRepository, InMemoryPizzaRepository>();
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
