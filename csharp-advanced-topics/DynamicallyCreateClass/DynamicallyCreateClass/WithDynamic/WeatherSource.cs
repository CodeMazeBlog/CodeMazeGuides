using Newtonsoft.Json;

namespace DynamicallyCreateClass.WithDynamic;

public class WeatherSource : AbstractWeatherSource
{
    public WeatherSource(int sourceIndex, double temperature, int humidity)
    {
        var jsonWeather = $@"{{ 'Temperature{sourceIndex}': {temperature}, 
            'Humidity{sourceIndex}': {humidity} }}";
        
        WeatherObject = new DynamicWeatherData(
            JsonConvert.DeserializeObject<dynamic>(jsonWeather));
    }
}