using MediatR;

namespace MediatrExceptionHandler.Common
{
    public class BaseRequest<TResponse> : IRequest<TResponse> where TResponse : WeatherResponse { }

    public class GetWeatherRequest : BaseRequest<WeatherResponse> { }
}
