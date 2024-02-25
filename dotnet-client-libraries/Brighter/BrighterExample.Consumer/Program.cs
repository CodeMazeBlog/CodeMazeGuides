using BrighterExample.Common;
using Paramore.Brighter;
using Paramore.Brighter.MessagingGateway.RMQ;
using Paramore.Brighter.ServiceActivator.Extensions.DependencyInjection;
using Paramore.Brighter.ServiceActivator.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var subscriptions = new Subscription[]
{
    new RmqSubscription<PingEvent>(
        new SubscriptionName("ping.consumer"),
        new ChannelName("ping.event"),
        new RoutingKey("ping.event"),
        isDurable: true,
        highAvailability: true
    ),
};

var rmqConnection = new RmqMessagingGatewayConnection
{
    AmpqUri = new AmqpUriSpecification(new Uri("amqp://guest:guest@localhost:5672")),
    Exchange = new Exchange("ping.exchange")
};

var rmqMessageConsumerFactory = new RmqMessageConsumerFactory(rmqConnection);

builder
    .Services.AddServiceActivator(options =>
    {
        options.Subscriptions = subscriptions;
        options.ChannelFactory = new ChannelFactory(rmqMessageConsumerFactory);
    })
    .AutoFromAssemblies();

builder.Services.AddHostedService<ServiceActivatorHostedService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
