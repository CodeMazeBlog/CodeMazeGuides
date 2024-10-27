using MassTransit;
using MassTransit.Serialization;
using MessagingComparisons.Domain;
using MessagingComparisons.Domain.Interfaces;
using MessagingComparisons.MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageHandler, MessageHandler>();
builder.Services.AddScoped<IMessageBusStrategy, MassTransitStrategy>();
builder.Services.AddScoped<ICustomMessageSender, MassTransitStrategy>();
builder.Services.AddScoped<IMessageSender, MessageSender>(sp => 
    new MessageSender(
        sp.GetRequiredService<IMessageBusStrategy>(),
        "MassTransit"
    ));

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

app.MapPost("/send-message", async (IMessageSender messageSender) =>
    {
        await messageSender.SendMessageAsync();
        
        return Results.Ok();
    })
    .WithName("Send Message")
    .WithOpenApi();

app.Run();