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
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeather")]
        public async Task<SomeResponse> GetWeather()
        {
            var result = await _mediator.Send(new SomeRequest());
            return result;
        }
    }
}