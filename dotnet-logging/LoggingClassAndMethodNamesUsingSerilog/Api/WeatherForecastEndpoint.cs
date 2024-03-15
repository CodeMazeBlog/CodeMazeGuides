using Serilog;
using ILogger = Serilog.ILogger;

namespace Api;

public class WeatherForecastEndpoint
{
    private readonly ILogger _logger = Log.ForContext<WeatherForecastEndpoint>();

    public IResult GetWeatherForecast()
    {
        _logger.WithClassAndMethodNames<WeatherForecastEndpoint>().Information("Get WeatherForecast called");
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot",
            "Sweltering", "Scorching"
        };
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            )).ToArray();

        return TypedResults.Ok(forecast);
    }
}