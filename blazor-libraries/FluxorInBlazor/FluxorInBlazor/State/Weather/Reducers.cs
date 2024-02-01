using Fluxor;
using FluxorInBlazor.State.Weather.Actions;

namespace FluxorInBlazor.State.Weather;

public static class Reducers
{
    [ReducerMethod(typeof(FetchDataAction))]
    public static WeatherState ReduceFetchDataAction(WeatherState state) => new() { IsLoading = true };
    
    [ReducerMethod]
    public static WeatherState ReduceDataFetchedAction(WeatherState state, DataFetchedAction action)
    {
        return new() {IsLoading = false, Forecasts = action.Forecasts};
    }
}