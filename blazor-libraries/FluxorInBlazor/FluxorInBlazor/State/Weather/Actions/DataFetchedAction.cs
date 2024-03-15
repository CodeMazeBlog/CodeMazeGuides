namespace FluxorInBlazor.State.Weather.Actions;

public record DataFetchedAction(IEnumerable<Pages.Weather.WeatherForecast> Forecasts);