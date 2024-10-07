using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.Transport.InMem;
using RebusVsNServiceBusVsMassTransit.Domain;
using RebusVsNServiceBusVsMassTransit.Rebus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMessageSender, MessageSender>();

builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseInMemoryTransport(new InMemNetwork(true), "MyQueue"))
    .Routing(r => r.TypeBased().MapAssemblyOf<Message>("MyQueue")));
builder.Services.AutoRegisterHandlersFromAssemblyOf<Program>();

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