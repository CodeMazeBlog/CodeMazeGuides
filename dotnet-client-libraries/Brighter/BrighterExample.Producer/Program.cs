using BrighterExample.Common;
using Paramore.Brighter;
using Paramore.Brighter.Extensions.DependencyInjection;
using Paramore.Brighter.MessagingGateway.RMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var rmqConnection = new RmqMessagingGatewayConnection
{
    AmpqUri = new AmqpUriSpecification(new Uri("amqp://guest:guest@localhost:5672")),
    Exchange = new Exchange("ping.exchange"),
};

var rmqProducerRegistry = new RmqProducerRegistryFactory(
    rmqConnection,
    [new() { Topic = new RoutingKey("ping.event") }]
).Create();

builder
    .Services.AddBrighter()
    .UseExternalBus(rmqProducerRegistry)
    .MapperRegistryFromAssemblies(typeof(PingEvent).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/produce", (IAmACommandProcessor commandProcessor) =>
    {
        commandProcessor.Post(new PingEvent());

        return Results.Ok();
    }
)
.WithOpenApi();

app.Run();
