using Common.Messaging;
using Common.Models.Messages;
using Microservice.PaymentProcessingService;
using Microservice.PaymentProcessingService.BackgroundWorkers;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

// Add services to the container.
builder.Services.AddSingleton<IPaymentProcessor, PaymentProcessor>();
builder.Services.AddSingleton<IMessageProducer<PaymentSuccess>, PaymentSuccessfulProducer>();
builder.Services.AddSingleton<IMessageProducer<Failure>, PaymentFailureProducer>();

builder.Services.AddSingleton(sp =>
{
    var uri = new Uri("amqps://oegrzndk:D7_WCL9BOCX-23_CS3Yo0C4rCphFa3Ys@lionfish.rmq.cloudamqp.com/oegrzndk");
    return new ConnectionFactory
    {
        Uri = uri,
        DispatchConsumersAsync = true
    };
});

builder.Services.AddHostedService<TaxConsumer>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/", () => "Microservice.PaymentProcessingService");

app.Run();