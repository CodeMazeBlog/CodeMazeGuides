public class WeatherData
{
    public WeatherData(double temperature, int humidity)
    {
        this.Temperature = temperature;
        this.Humidity = humidity;
    }

    public double Temperature { get; init; }
    public int Humidity { get; init; }
}
