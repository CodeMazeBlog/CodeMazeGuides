using Microsoft.AspNetCore.Mvc;

namespace ConditionalMiddleware.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpPost("post-weather")]
    public IActionResult SaveWeather()
    {
        return Ok();
    }

    [HttpPut("update-weather")]
    public IActionResult UpdateWeather()
    {
        return Ok();
    }
}

