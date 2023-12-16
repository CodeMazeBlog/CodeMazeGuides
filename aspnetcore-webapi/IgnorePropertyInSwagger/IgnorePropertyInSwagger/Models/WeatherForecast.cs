using IgnorePropertyInSwagger.Attributes;

namespace IgnorePropertyInSwagger.Models;

public record WeatherForecast
{
    public WeatherForecast(DateOnly date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    [SwaggerIgnore]
    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
    public DateOnly Date { get; init; }
    public int TemperatureC { get; init; }
    public string? Summary { get; init; }
}