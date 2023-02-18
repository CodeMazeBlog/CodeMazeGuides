using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using CodeMazeShop.Services.Payment.Messaging;
using CodeMazeShop.Services.Payment.Services;
using CodeMazeShop.Services.Payment.Workers;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IPaymentService, PaymentService>(c =>
               c.BaseAddress = new Uri(configuration["ServiceConfigs:PaymentGateway:Uri"]));

builder.Services.AddSingleton<IMessageProducer<PaymentUpdateMessage>, PaymentUpdateProducer>();
builder.Services.AddSingleton(sp =>
{
    var uri = new Uri(configuration["RabbitMq:Uri"]);
    return new ConnectionFactory
    {
        Uri = uri,
        DispatchConsumersAsync = true
    };
});

builder.Services.AddHostedService<PaymentRequestConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
