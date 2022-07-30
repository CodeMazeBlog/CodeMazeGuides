using System.Dynamic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DynamicallyCreateClass.WithExpando;

public class WeatherSource : AbstractWeatherSource
{
    public WeatherSource(int sourceIndex, double temperature, int humidity) 
    {
        var jsonWeather1 = $@"{{ 'Temperature{sourceIndex}': {temperature}, 
            'Humidity{sourceIndex}': {humidity} }}";

        var expandoConverter = new ExpandoObjectConverter();
        WeatherObject = JsonConvert.DeserializeObject<ExpandoObject>(
            jsonWeather1, expandoConverter)!;

        var toCsvFormatter = (dynamic thisObj) => () => {
            StringBuilder sb = new StringBuilder();

            foreach (var prop in (IDictionary<String, Object>)thisObj)
                if (prop.Key != "Format")
                    sb.Append($"{prop.Value},");

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        };

        WeatherObject.Format = toCsvFormatter(WeatherObject);
    }
}