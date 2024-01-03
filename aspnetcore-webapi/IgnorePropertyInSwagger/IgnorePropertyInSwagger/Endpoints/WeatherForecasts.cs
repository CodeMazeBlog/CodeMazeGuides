using IgnorePropertyInSwagger.Models;

namespace IgnorePropertyInSwagger.Endpoints;

public static class WeatherForecasts
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public static void MapWeatherForecasts(this IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", () =>
            {
                return Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            Summaries[Random.Shared.Next(Summaries.Length)]
                        ))
                    .ToArray();
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();
    }
}