using System.ComponentModel;

namespace DynamicallyCreateClass.WithExpando;

public class WeatherAggregator
{
    private dynamic _weather1;
    private dynamic _weather2;
    private dynamic _weather3;
    private WeatherData _aggregatedWeather = default!;

    public WeatherData AggregatedWeather 
    {
        get => _aggregatedWeather;
    }

    public WeatherAggregator(dynamic weatherExpando1, 
                             dynamic weatherExpando2, 
                             dynamic weatherExpando3)
    {
        _weather1 = weatherExpando1;
        _weather2 = weatherExpando2;
        _weather3 = weatherExpando3;

        foreach (var weatherExp in new dynamic[] { _weather1, _weather2, _weather3 })
        {
            ((INotifyPropertyChanged)weatherExp).PropertyChanged += 
                new PropertyChangedEventHandler((sender, e) => {
                    ComputeAggregatedWeather();
                });
        }

        ComputeAggregatedWeather();
    }

    public void RoundWeatherDataForSource1() {
        _weather1.Temperature1 = Math.Round(_weather1.Temperature1);
    }

    private void ComputeAggregatedWeather()
    {
        _aggregatedWeather = new WeatherData(
            new double[] { _weather1.Temperature1, _weather2.Temperature2, _weather3.Temperature3 }
                .Average(),
            (int)new int[] { (int)_weather1.Humidity1, (int)_weather2.Humidity2, (int)_weather3.Humidity3 }
                .Average());
    }
}
