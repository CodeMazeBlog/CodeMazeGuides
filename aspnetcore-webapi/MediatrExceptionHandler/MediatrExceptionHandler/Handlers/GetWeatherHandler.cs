using MediatR;
using MediatrExceptionHandler.Requests;

namespace MediatrExceptionHandler.Handlers
{
    public class GetWeatherHandler : IRequestHandler<GetWeatherRequest, IEnumerable<WeatherForecast>>
    {
        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
