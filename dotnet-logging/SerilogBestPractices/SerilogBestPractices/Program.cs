using Serilog;
using SerilogBestPractices.Enrichers;
using SerilogBestPractices.Models;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
        "logs/log.txt",
        retainedFileCountLimit: 21,
        rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Host.UseSerilog((context, config) =>
        config.ReadFrom.Configuration(context.Configuration)
            .Enrich.With(new ThreadPriorityEnricher()));

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSerilogRequestLogging(options
      => options.EnrichDiagnosticContext = RequestEnricher.LogAdditionalInfo);

    app.UseHttpsRedirection();

    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    app.MapGet("/weatherforecast", (ILoggerFactory factory) =>
    {
        var logger = factory.CreateLogger("GetWeatherForecast");

        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();

        logger.LogInformation(
            "The weather today will be {Summary} and {Temperature} degrees.",
            forecast[0].Summary,
            forecast[0].TemperatureC);

        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "The exception was thrown during application startup");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program { }
