using Rebus.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRebus(configure =>
{
    var configurer = configure
    .Logging(l => l.ColoredConsole())
    .Transport(t => t.UseRabbitMqAsOneWayClient("amqp://guest:guest@localhost:5672"))
    .Options(o => o.EnableFleetManager("https://api.rebus.fm", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJhaWQiOiJ0LXRlYW0yMi0xIiwidXBuIjoidXNlcjczNiIsIndoZW4iOiIxNjcwOTUxOTcyNDUyIn0.WNdYpNPiRr4_ATP10xTdXBjYPuGRW75QSO1rQXy3E85905kSSvFAFdukePB5NckliVRbbxlqNSmo9PA6k9pPwA"));

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
