using MediatR;
using MediatrExceptionHandler.Common;
using Microsoft.AspNetCore.Mvc;

namespace MediatrExceptionHandler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeather")]
        public async Task<WeatherResponse> GetWeather()
        {
            var result = await _mediator.Send(new GetWeatherRequest());
            return result;
        }
    }
}