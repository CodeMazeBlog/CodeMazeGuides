using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;
using MessagingComparisons.NServiceBus;
using NServiceBus.Encryption.MessageProperty;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageHandler, MessageHandler>();
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

    recoverability.Immediate(immediate => 
        immediate.NumberOfRetries(3)
    );

    recoverability.Delayed(delayed =>
    {
        delayed.NumberOfRetries(2); 
        delayed.TimeIncrease(TimeSpan.FromSeconds(5));
    });

    recoverability.CustomPolicy((config, context) =>
    {
        if (context.Exception is TimeoutException)
        {
            return RecoverabilityAction.ImmediateRetry();
        }
        
        return RecoverabilityAction.MoveToError("ErrorQueue");
    });

    endpointConfiguration.SendFailedMessagesTo("ErrorQueue");

    var encryptionService = new AesEncryptionService(
        encryptionKeyIdentifier: "2024-10", 
        key: Convert.FromBase64String("mK8nD2pL9qR5vX7hJ4tF3wA6cE1bN0yZ")); 

    endpointConfiguration.EnableMessagePropertyEncryption(
        encryptionService: encryptionService,
        encryptedPropertyConvention: propertyInfo => 
            propertyInfo.Name.Equals(nameof(Message.Content))
    );

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

app.MapPost("/send-message", async (IMessageSender messageSender) =>
    {
        await messageSender.SendMessageAsync();
        
        return Results.Ok();
    })
    .WithName("Send Message")
    .WithOpenApi();

app.Run();