using MediatR;

namespace MediatrExceptionHandler.Requests
{
    public record GetWeatherRequest : IRequest<IEnumerable<WeatherForecast>>;
}
