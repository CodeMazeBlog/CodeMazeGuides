using Microservice.ReceiptGeneratorService;
using Microservice.ReceiptGeneratorService.BackgroundWorkers;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(sp =>
{
    var uri = new Uri("URL FOR RABBITMQ SERVER");
    return new ConnectionFactory
    {
        Uri = uri,
        DispatchConsumersAsync = true
    };
});

builder.Services.AddSingleton<IReceiptGenerator, ReceiptGenerator>();

builder.Services.AddHostedService<PaymentFailureConsumer>();
builder.Services.AddHostedService<PaymentSuccessfulConsumer>();
builder.Services.AddHostedService<StockValidationFailureConsumer>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/", () => "Microservice.ReceiptGeneratorService");

app.Run();