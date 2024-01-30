using Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Tests;

public class WeatherForecastEndpointTest
{
    [Fact]
    public void WhenWeatherForecastEndpointIsCalled_ThenHttpResponseIsOk()
    {
        var weatherForecastEndpoint = new WeatherForecastEndpoint();

        var httpResponse = (Ok<WeatherForecast[]>)weatherForecastEndpoint.GetWeatherForecast();

        Assert.Equal(StatusCodes.Status200OK, httpResponse.StatusCode);
    }
}