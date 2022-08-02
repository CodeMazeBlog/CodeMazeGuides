using Common.Messaging;
using Common.Models.Messages;
using Microservice.TaxCalculatorService;
using Microservice.TaxCalculatorService.BackgroundWorkers;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

// Add services to the container.

builder.Services.AddSingleton<ICalculator, Calculator>();
builder.Services.AddSingleton<IMessageProducer<Tax>, TaxProducer>();

builder.Services.AddSingleton(sp =>
{
    var uri = new Uri("URL FOR RABBITMQ SERVER");
    return new ConnectionFactory
    {
        Uri = uri,
        DispatchConsumersAsync = true
    };
});

builder.Services.AddHostedService<StockValidationSuccessConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/", () => "Microservice.TaxCalculatorService");

app.Run();