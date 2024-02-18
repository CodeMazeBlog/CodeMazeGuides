using System.Net.Http.Json;
using Fluxor;
using FluxorInBlazor.State.Weather.Actions;

namespace FluxorInBlazor.State.Weather;

public class Effects(HttpClient http)
{
    [EffectMethod(typeof(FetchDataAction))]
    public async Task HandleFetchDataAction(IDispatcher dispatcher)
    {
        var forecasts = await http.GetFromJsonAsync<Pages.Weather.WeatherForecast[]>("sample-data/weather.json") 
                        ?? Array.Empty<Pages.Weather.WeatherForecast>();
        dispatcher.Dispatch(new DataFetchedAction(forecasts));
    }
}