using FluentValidation.TestHelper;
using WebApplication1;

namespace WebApplication1.Tests;

public class WeatherForecastValidatorTests
{
    private readonly WeatherForecastValidator _validator = new WeatherForecastValidator();

    [Fact]
    public void GivenAnInvalidTemperatureCValue_ShouldHaveValidationError()
    {
        var forecast = new WeatherForecast { TemperatureC = 101 };

        var result = _validator.TestValidate(forecast);

        result.ShouldHaveValidationErrorFor(model => model.TemperatureC);
    }

    [Theory]
    [InlineData(99)]
    [InlineData(100)]
    public void GivenAValidTemperatureCValue_ShouldNotHaveValidationError(int temperatureC)
    {
        var forecast = new WeatherForecast { TemperatureC = temperatureC };

        var result = _validator.TestValidate(forecast);

        result.ShouldNotHaveValidationErrorFor(model => model.TemperatureC);
    }
}
