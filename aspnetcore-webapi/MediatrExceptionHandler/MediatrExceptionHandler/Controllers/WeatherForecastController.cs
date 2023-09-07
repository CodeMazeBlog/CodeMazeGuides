using MediatR;
using MediatrExceptionHandler.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediatrExceptionHandler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeather")]
        public async Task<IEnumerable<WeatherForecast>> GetWeather()
        {
            var result = await _mediator.Send(new GetWeatherRequest());
            return result;
        }
    }
}