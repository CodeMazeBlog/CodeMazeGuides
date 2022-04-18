using Common.Messaging;
using Common.Models.Messages;
using Microservice.StockValidatorService;
using Microservice.StockValidatorService.BackgroundWorkers;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

// Add services to the container.
builder.Services.AddSingleton<IValidator, Validator>();
builder.Services.AddSingleton<IMessageProducer<CheckoutItem>, StockValidationSuccessfulProducer>();
builder.Services.AddSingleton<IMessageProducer<Failure>, StockValidationFailureProducer>();

builder.Services.AddSingleton(sp =>
{
    var uri = new Uri("amqps://oegrzndk:D7_WCL9BOCX-23_CS3Yo0C4rCphFa3Ys@lionfish.rmq.cloudamqp.com/oegrzndk");
    return new ConnectionFactory
    {
        Uri = uri,
        DispatchConsumersAsync = true
    };
});

builder.Services.AddHostedService<StockValidatorConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapGet("/", () => "Microservice.StockValidatorService");

app.Run();

