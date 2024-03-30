using Inventory;
using Order;
using Testcontainers.RabbitMq;


var builder = WebApplication.CreateBuilder(args);

var rabbitMqContainer = new RabbitMqBuilder()
       .WithHostname(builder.Configuration["RabbitMq:HostName"])
       .WithPortBinding(builder.Configuration.GetValue<int>("RabbitMq:Port"))
       .WithExposedPort(builder.Configuration.GetValue<int>("RabbitMq:Port"))
       .WithPortBinding(builder.Configuration.GetValue<int>("RabbitMq:DashboardPort"))
       .WithExposedPort(builder.Configuration.GetValue<int>("RabbitMq:DashboardPort"))
       .WithUsername(builder.Configuration["RabbitMq:UserName"])
       .WithPassword(builder.Configuration["RabbitMq:Password"])
       .WithImage("rabbitmq:3-management")
       .Build();

await rabbitMqContainer.StartAsync();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

// Add module services
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

