using MassTransit;
using MessagingComparisons.Domain;
using MessagingComparisons.MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMessageBusStrategy, MassTransitStrategy>();
builder.Services.AddScoped<IMessageSender, MessageSender>(sp => 
    new MessageSender(
        sp.GetRequiredService<IMessageBusStrategy>(),
        "MassTransit"
    ));

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageHandler>(); 
    x.UsingInMemory((context, cfg) =>
    {
        cfg.ReceiveEndpoint("MyQueue", e =>
        {
            e.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(2)));
            e.ConfigureConsumer<MessageHandler>(context);
        });
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

app.MapPost("/payment", async (IMessageSender messageSender) =>
    {
        await messageSender.SendMessageAsync();
        
        return Results.Ok();
    })
    .WithName("Payment")
    .WithOpenApi();

app.Run();