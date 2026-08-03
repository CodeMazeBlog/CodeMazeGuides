using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Configuration;
using MessagingComparisons.Domain.Interfaces;
using MessagingComparisons.NServiceBus;
using NServiceBus.Encryption.MessageProperty;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageHandler, MessageHandler>();
builder.Services.AddScoped<IMessageSender, NServiceBusMessageSender>();

var encryptionConfig = builder.Configuration.GetSection("Encryption").Get<EncryptionConfiguration>();
var encryptionKeyId = encryptionConfig?.KeyId ?? "";
var encryptionKey = encryptionConfig?.Key ?? "";

builder.Host.UseNServiceBus(context =>
{
    var endpointConfiguration = new EndpointConfiguration("HandlerEndpoint");

    var transport = endpointConfiguration.UseTransport<LearningTransport>();
    var serialization = endpointConfiguration.UseSerialization<SystemJsonSerializer>();

    var conventions = endpointConfiguration.Conventions();
    conventions.DefiningMessagesAs(type => type.Namespace == typeof(Message).Namespace);

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
        encryptionKeyIdentifier: encryptionKeyId,
        key: Convert.FromBase64String(encryptionKey));

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

app.MapPost("/send-message", async (IMessageSender messageSender, string content) =>
    {
        var message = new Message
        {
            MessageId = Guid.NewGuid().ToString(),
            Content = content
        };

        await messageSender.SendMessageAsync(message);
        
        return Results.Ok();
    })
    .WithName("Send Message")
    .WithOpenApi();

app.Run();
