using RebusVsNServiceBusVsMassTransit.Domain;
using RebusVsNServiceBusVsMassTransit.NServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMessageSender, MessageSender>();

builder.Host.UseNServiceBus(context =>
{
    var endpointConfiguration = new EndpointConfiguration("CheckoutEndpoint");
    var transport = endpointConfiguration.UseTransport<LearningTransport>();
    var persistence = endpointConfiguration.UsePersistence<LearningPersistence>();
    var serialization = endpointConfiguration.UseSerialization<SystemJsonSerializer>();
    var conventions = endpointConfiguration.Conventions();
    conventions.DefiningMessagesAs(type => type.Namespace == "RebusVsNServiceBusVsMassTransit.Domain");
    var routing = transport.Routing();
    routing.RouteToEndpoint(typeof(ProcessPayment), "CheckoutEndpoint");

    return endpointConfiguration;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/payment", async (IMessageSender messageSender) =>
    {
        await messageSender.SendMessageAsync();
        
        return Results.Ok();
    })
    .WithName("Payment")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}