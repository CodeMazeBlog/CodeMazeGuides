using FixUnableToResolveServiceIssue.Interfaces;
using FixUnableToResolveServiceIssue.Services;
using FixUnableToResolveServiceIssue.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Add this line to register the service with a scoped lifetime in the dependency injection container:
builder.Services.AddScoped<IUserService, UserService>();

// A plain string cannot be resolved by type, so the SMTP values are bound to an options class
// and EmailService asks for IOptions<SmtpSettings> instead:
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddScoped<EmailService>();

// Registers IHttpClientFactory and makes a plain HttpClient injectable:
builder.Services.AddHttpClient();

// Registers WeatherClient as a typed client with its own configured HttpClient:
builder.Services.AddHttpClient<WeatherClient>(client =>
{
    client.BaseAddress = new Uri("https://api.example.com/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// For testing purposes
public partial class Program { }