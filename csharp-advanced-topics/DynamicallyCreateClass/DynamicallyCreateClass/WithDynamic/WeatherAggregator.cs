namespace DynamicallyCreateClass.WithDynamic;

public class WeatherAggregator
{
    private WeatherData[] _weatherData;
    public WeatherData AggregatedWeather
    {
        get =>
            new WeatherData(
                _weatherData.Select(wd => wd.Temperature).Average(),
                (int)_weatherData.Select(wd => wd.Humidity).Average()
            );
    }

    public WeatherAggregator(params WeatherData[] weatherData)
    {
        _weatherData = weatherData;
    }
}
