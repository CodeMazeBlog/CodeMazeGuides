using FluxorInBlazor.Pages;
using FluxorInBlazor.State.Weather;
using FluxorInBlazor.State.Weather.Actions;

namespace FluxorInBlazor.Tests;

public class WeatherReducersUnitTest
{
    [Test]
    public void GivenEmptyWeatherState_WhenFetchDataActionIsReduced_ThenShouldCreateNewStateWithLoadingTrueAndEmptyForecasts()
    {
        var oldState = new WeatherState();
        
        var newState = Reducers.ReduceFetchDataAction(oldState);
        
        Assert.That(newState.IsLoading, Is.True);
        Assert.That(newState.Forecasts, Is.Empty);
    }
    
    [Test]
    public void GivenLoadingWeatherState_WhenDataFetchedActionIsReduced_ThenShouldCreateNewStateWithLoadingFalseAndForecasts()
    {
        var oldState = new WeatherState { IsLoading = true };
        var action = new DataFetchedAction(new List<Weather.WeatherForecast> {new() {Date = DateOnly.MaxValue, TemperatureC = 20}});
        
        var newState = Reducers.ReduceDataFetchedAction(oldState, action);
        
        Assert.That(newState.IsLoading, Is.False);
        Assert.That(newState.Forecasts, Is.Not.Null);
        Assert.That(newState.Forecasts.Count(), Is.EqualTo(1));
    }
}