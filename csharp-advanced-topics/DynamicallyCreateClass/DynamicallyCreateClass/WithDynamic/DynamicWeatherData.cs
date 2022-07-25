using System.Dynamic;
using Newtonsoft.Json.Linq;

namespace DynamicallyCreateClass.WithDynamic;

public class DynamicWeatherData : DynamicObject
{
    JObject _weatherData;
    public DynamicWeatherData(JObject weatherData)
    {
        _weatherData = weatherData;
    }

    public override bool TrySetMember(
        SetMemberBinder binder, object? value)
    {
        if (!_weatherData.ContainsKey(binder.Name))
            return false;

        _weatherData[binder.Name] = value == null ? null : JToken.FromObject(value);

        return true;
    }

    public override bool TryGetMember(
        GetMemberBinder binder, out object? result)
    {
        if (!_weatherData.ContainsKey(binder.Name))
        {
            result = null;
            return false;
        }

        result = _weatherData[binder.Name]!.ToObject<object>();
        return true;
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, 
                                         object?[]? args, 
                                         out object? result)
    {
        if (binder.Name == "Format" && args?.Length == 0) 
        {
            var (temperature, humidity) = GetProperties();

            result = $"{temperature},{humidity}";
            return true;
        }
        else
        {
            result = null;
            return false;
        }
    }

    public override bool TryConvert(ConvertBinder binder, out object? result)
    {
        if (binder.Type.Equals(typeof(WeatherData)))
        {
            var (temperature, humidity) = GetProperties();

            result = new WeatherData(temperature, humidity);
            return true;
        }
        else 
        {
            result = null;
            return false;
        }
    }

    private (double, int) GetProperties() 
    {
        var temperatureAttr = _weatherData.Properties()
            .First(jp => jp.Name.StartsWith("Temperature"))
            .ToObject<double>();
        var humidityAttr = _weatherData.Properties()
            .First(jp => jp.Name.StartsWith("Humidity"))
            .ToObject<int>();

        return (temperatureAttr, humidityAttr);
    }
}