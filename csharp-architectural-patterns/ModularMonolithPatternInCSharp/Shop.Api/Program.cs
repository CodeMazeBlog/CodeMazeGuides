using Shop.Api;
using Shop.Inventory;
using Shop.Orders;
using Shop.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddSingleton<InProcessEventBus>();
builder.Services.AddSingleton<IEventBus>(sp => sp.GetRequiredService<InProcessEventBus>());
builder.Services.AddHostedService<EventDispatcher>();

builder.Services.AddInventoryModule();
builder.Services.AddOrdersModule();

var app = builder.Build();

app.UseExceptionHandler();

app.MapInventoryEndpoints();
app.MapOrdersEndpoints();

app.Run();
