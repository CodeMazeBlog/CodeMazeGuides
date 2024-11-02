using MassTransit;
using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;
using MessagingComparisons.MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageHandler, MessageHandler>();
builder.Services.AddScoped<IMessageSender, MassTransitMessageSender>();
builder.Services.AddScoped<ICustomMessageSender, MassTransitMessageSender>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MassTransitMessageHandler>(); 
    x.UsingInMemory((context, cfg) =>
    {
        cfg.ReceiveEndpoint("MyQueue", e =>
        {
            e.ConfigureConsumer<MassTransitMessageHandler>(context);
            e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(2)));
        });
        cfg.UseEncryption(Convert.FromBase64String("mK8nD2pL9qR5vX7hJ4tF3wA6cE1bN0yZ"));
    });
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
