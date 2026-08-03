namespace ResolvingDependencyInjection.Models
{
    public class CityForecast
    {
        public string? CityName { get; set; }
        public IEnumerable<WeatherForecast>? WeatherForecasts { get; set; }
    }
}
