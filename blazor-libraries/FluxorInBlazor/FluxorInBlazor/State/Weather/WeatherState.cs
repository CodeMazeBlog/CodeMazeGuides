using Fluxor;

namespace FluxorInBlazor.State.Weather;

[FeatureState]
public record WeatherState
{
    public bool IsLoading { get; init; }
    public IEnumerable<Pages.Weather.WeatherForecast> Forecasts { get; init; } = new List<Pages.Weather.WeatherForecast>();
}