using System.Text.Json;
using System.Text.Json.Nodes;

namespace DynamicallyCreateClass.WithDynamic;

public class WeatherSource : AbstractWeatherSource
{
    public WeatherSource(int sourceIndex, double temperature, int humidity)
    {
        var jsonWeather =
            $@"{{ ""Temperature{sourceIndex}"": {temperature}, 
            ""Humidity{sourceIndex}"": {humidity} }}";

        WeatherObject = new DynamicWeatherData(
            JsonSerializer.Deserialize<JsonObject>(jsonWeather)!
        );
    }
}
