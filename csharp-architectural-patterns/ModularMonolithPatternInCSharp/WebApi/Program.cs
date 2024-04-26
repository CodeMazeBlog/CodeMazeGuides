using Common.RabbitMq;
using Inventory;
using Order;
using Testcontainers.RabbitMq;


var builder = WebApplication.CreateBuilder(args);

var rabbitMqContainer = new RabbitMqBuilder()
       .WithHostname(builder.Configuration["RabbitMqConfiguration:HostName"])
       .WithPortBinding(builder.Configuration.GetValue<int>("RabbitMqConfiguration:Port"))
       .WithExposedPort(builder.Configuration.GetValue<int>("RabbitMqConfiguration:Port"))
       .WithPortBinding(builder.Configuration.GetValue<int>("RabbitMqConfiguration:DashboardPort"))
       .WithExposedPort(builder.Configuration.GetValue<int>("RabbitMqConfiguration:DashboardPort"))
       .WithUsername(builder.Configuration["RabbitMqConfiguration:UserName"])
       .WithPassword(builder.Configuration["RabbitMqConfiguration:Password"])
       .WithImage("rabbitmq:3-management")
       .Build();

await rabbitMqContainer.StartAsync();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddRabbitMqConnectionManager(builder.Configuration);
builder.Services.AddInventoryModule();
builder.Services.AddOrderModule();

var app = builder.Build();

var appLifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();

appLifetime.ApplicationStopping.Register(() =>
{
    rabbitMqContainer.StopAsync()
    .GetAwaiter()
    .GetResult();
});

app.UseRabbitMqConnectionManager();
app.UseOrderConsumer();

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


