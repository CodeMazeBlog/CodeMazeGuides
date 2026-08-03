using MediatR;

namespace MediatrExceptionHandler.Common
{
    public class BaseRequest<TResponse> : IRequest<TResponse> where TResponse : BaseResponse { }

    public class GetWeatherRequest : BaseRequest<WeatherResponse> { }
}
