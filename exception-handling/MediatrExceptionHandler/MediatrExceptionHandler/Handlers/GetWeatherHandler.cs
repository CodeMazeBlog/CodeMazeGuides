using MediatR;
using MediatrExceptionHandler.Common;

namespace MediatrExceptionHandler.Handlers
{
    public class GetWeatherHandler : IRequestHandler<GetWeatherRequest, WeatherResponse>
    {
        public Task<WeatherResponse> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
