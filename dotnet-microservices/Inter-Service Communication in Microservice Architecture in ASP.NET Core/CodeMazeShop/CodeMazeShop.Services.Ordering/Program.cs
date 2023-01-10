using CodeMazeShop.Integration.Abstractions;
using CodeMazeShop.Integration.Messages;
using CodeMazeShop.Services.Ordering;
using CodeMazeShop.Services.Ordering.Messaging;
using CodeMazeShop.Services.Ordering.Repositories;
using CodeMazeShop.Services.Ordering.Workers;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderCreatorService, OrderCreatorService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase("OrdersDb"));

builder.Services.AddSingleton<IMessageProducer<PaymentRequestMessage>, PaymentRequestProducer>();
builder.Services.AddSingleton(sp =>
{
    var uri = new Uri(configuration["RabbitMq:Uri"]);
    return new ConnectionFactory
    {
        Uri = uri,
        DispatchConsumersAsync = true
    };
});

builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddHostedService<CheckoutConsumer>();
builder.Services.AddHostedService<PaymentUpdateConsumer>();

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
