using Api;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

#region Old Serilog Configuration

// builder.Host.UseSerilog((context, configuration) =>
// {
//     configuration
//         .MinimumLevel.Debug()
//         .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//         .Enrich.FromLogContext()
//         .WriteTo.Console(
//             outputTemplate:
//             "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {SourceContext} {Message} (at {ClassName} class in {MethodName} method){NewLine}{Exception}"
//         );
// });

#endregion

builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console(new CustomJsonFormatter());
});

// Add services to the container.
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
app.MapGet("/weatherforecast", new WeatherForecastEndpoint().GetWeatherForecast)
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();