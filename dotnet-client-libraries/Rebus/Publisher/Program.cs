using Rebus.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRebus(configure =>
{
    var configurer = configure
    .Logging(l => l.ColoredConsole())
    .Transport(t => t.UseRabbitMqAsOneWayClient("amqp://guest:guest@localhost:5672"))
    .Options(o => o.EnableFleetManager("https://api.rebus.fm", "<API_KEY>"));

    return configurer;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
