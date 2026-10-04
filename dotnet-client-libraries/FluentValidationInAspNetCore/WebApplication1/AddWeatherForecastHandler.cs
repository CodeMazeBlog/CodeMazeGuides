using FluentValidation;

namespace WebApplication1;

public class AddWeatherForecastHandler(IValidator<WeatherForecast> validator)
{
    public async Task HandleAsync(WeatherForecast forecast, CancellationToken cancellationToken = default)
    {
        await validator.ValidateAndThrowAsync(forecast, cancellationToken);

        // A real use case would save the forecast here.
    }
}
