using ReadAppSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.ConfigureAppConfiguration(config =>
{
    config.AddJsonFile("config.json");
});
builder.Services.Configure<FormatSettings>(builder.Configuration.GetSection("Formatting"));
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();

public partial class Program { }