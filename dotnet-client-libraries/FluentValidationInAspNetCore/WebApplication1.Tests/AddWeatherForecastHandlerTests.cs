using FluentValidation;
using WebApplication1;

namespace WebApplication1.Tests;

public class AddWeatherForecastHandlerTests
{
    [Fact]
    public async Task GivenAnInvalidForecast_HandlerShouldThrowBeforeSaving()
    {
        var handler = new AddWeatherForecastHandler(new WeatherForecastValidator());

        var forecast = new WeatherForecast { TemperatureC = 6000 };

        await Assert.ThrowsAsync<ValidationException>(() => handler.HandleAsync(forecast));
    }
}
