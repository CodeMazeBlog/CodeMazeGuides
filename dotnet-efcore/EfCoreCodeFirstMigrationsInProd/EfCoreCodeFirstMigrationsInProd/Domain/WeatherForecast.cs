namespace EfCoreCodeFirstMigrationsInProd.Domain;

public class WeatherForecast(DateOnly date, int temperatureC, string? summary)
{
    public Guid Id { get; private set; }
    public DateOnly Date { get; private set; } = date;
    public int TemperatureC { get; private set; } = temperatureC;
    public string? Summary { get; private set; } = summary;
    
    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

    private WeatherForecast() : this(default, default, default)
    {
    }
}