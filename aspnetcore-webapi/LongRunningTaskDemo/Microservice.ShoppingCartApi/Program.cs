using System.Text.Json.Serialization;
using Common.Messaging;
using Common.Models.Messages;
using Microservice.ShoppingCartApi;
using Microservice.ShoppingCartApi.BackgroundWorkers;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICheckoutProcessor, CheckoutProcessor>();
builder.Services.AddSingleton<IMessageProducer<CheckoutItem>, CheckoutItemProducer>();
builder.Services.AddSingleton(sp =>
{
    var uri = new Uri("amqps://oegrzndk:D7_WCL9BOCX-23_CS3Yo0C4rCphFa3Ys@lionfish.rmq.cloudamqp.com/oegrzndk");
    return new ConnectionFactory
    {
        Uri = uri
    };
});
builder.Services.AddHostedService<CheckoutBackgroundWorker>();


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

public partial class Program { }
