namespace Tests;

public class WeatherForecastLiveTest
{
    [Fact]
    public async Task WhenSendingAGetRequestToTheWeatherForecastEndpoint_ThenWeatherDataIsReturned()
    {
        // Arrange.
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7251")
        };

        // Act.
        var weatherForecasts = await httpClient.GetFromJsonAsync<WeatherForecast[]>("weatherforecast");

        // Assert.
        Assert.NotNull(weatherForecasts);
        Assert.NotEmpty(weatherForecasts);
        
        foreach (var weatherForecast in weatherForecasts)
        {
            Assert.True(weatherForecast.Date > DateTime.MinValue);
            Assert.True(weatherForecast.TemperatureC != 0);
            Assert.True(weatherForecast.TemperatureF != 0);
        }
    }
}

public record WeatherForecast(DateTime Date, int TemperatureC, int TemperatureF, string? Summary);