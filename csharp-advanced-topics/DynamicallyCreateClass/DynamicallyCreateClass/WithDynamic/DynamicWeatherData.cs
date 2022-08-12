using System.Dynamic;
using System.Text.Json.Nodes;

namespace DynamicallyCreateClass.WithDynamic;

public class DynamicWeatherData : DynamicObject
{
    JsonObject _weatherData;

    public DynamicWeatherData(JsonObject weatherData)
    {
        _weatherData = weatherData;
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        if (!_weatherData.ContainsKey(binder.Name))
            return false;

        _weatherData[binder.Name] = value == null ? null : JsonValue.Create(value);

        return true;
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        if (!_weatherData.ContainsKey(binder.Name))
        {
            result = null;
            return false;
        }

        result = _weatherData[binder.Name]?.AsValue();
        return true;
    }

    public override bool TryInvokeMember(
        InvokeMemberBinder binder,
        object?[]? args,
        out object? result
    )
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
        var temperatureAttr = _weatherData
            .First(kv => kv.Key.StartsWith("Temperature"))
            .Value!.GetValue<double>();
        var humidityAttr = _weatherData
            .First(kv => kv.Key.StartsWith("Humidity"))
            .Value!.GetValue<int>();

        return (temperatureAttr, humidityAttr);
    }
}
