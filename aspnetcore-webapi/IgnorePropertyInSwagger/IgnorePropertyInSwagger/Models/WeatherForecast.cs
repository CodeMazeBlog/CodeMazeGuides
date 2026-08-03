using IgnorePropertyInSwagger.Attributes;

namespace IgnorePropertyInSwagger.Models;

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    [SwaggerIgnore]
    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
}