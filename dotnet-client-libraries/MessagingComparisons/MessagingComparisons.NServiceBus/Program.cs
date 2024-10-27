using MessagingComparisons.Domain;
using MessagingComparisons.NServiceBus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageBusStrategy, NServiceBusStrategy>();
builder.Services.AddScoped<IMessageSender, MessageSender>(sp => 
    new MessageSender(
        sp.GetRequiredService<IMessageBusStrategy>(),
        "NServiceBus"
    ));

builder.Host.UseNServiceBus(context =>
{
    var endpointConfiguration = new EndpointConfiguration("HandlerEndpoint");
    var transport = endpointConfiguration.UseTransport<LearningTransport>();
    var serialization = endpointConfiguration.UseSerialization<SystemJsonSerializer>();
    var routing = transport.Routing();
    routing.RouteToEndpoint(typeof(Message), "HandlerEndpoint");
    var recoverability = endpointConfiguration.Recoverability();
    recoverability.Immediate(immediate => immediate.NumberOfRetries(3));
    recoverability.Delayed(delayed =>
    {
        delayed.NumberOfRetries(2); 
        delayed.TimeIncrease(TimeSpan.FromSeconds(5));
    });
    endpointConfiguration.SendFailedMessagesTo("ErrorQueue");

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