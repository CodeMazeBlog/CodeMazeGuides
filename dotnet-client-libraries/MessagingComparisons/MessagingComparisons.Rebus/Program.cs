using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Configuration;
using MessagingComparisons.Domain.Interfaces;
using MessagingComparisons.Rebus;
using Rebus.Config;
using Rebus.Encryption;
using Rebus.Retry.Simple;
using Rebus.Routing.TypeBased;
using Rebus.Transport.InMem;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageHandler, MessageHandler>();
builder.Services.AddScoped<IMessageSender, RebusMessageSender>();

var encryptionConfig = builder.Configuration.GetSection("Encryption").Get<EncryptionConfiguration>();
var encryptionKey = encryptionConfig?.Key ?? "";

builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseInMemoryTransport(new InMemNetwork(true), "MyQueue"))
    .Routing(r => r.TypeBased().MapAssemblyOf<Message>("MyQueue"))
    .Options(o =>
    {
        o.RetryStrategy(
            maxDeliveryAttempts: 5,
            secondLevelRetriesEnabled: true,
            errorQueueName: "ErrorQueue");
        o.EnableEncryption(encryptionKey);
    }));
builder.Services.AutoRegisterHandlersFromAssemblyOf<Program>();

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
