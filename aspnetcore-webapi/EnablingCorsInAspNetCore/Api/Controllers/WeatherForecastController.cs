using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [EnableCors("CorsPolicy")]
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            rng.Next(-20, 55),
            Summaries[rng.Next(Summaries.Length)]
        ))
        .ToArray();
    }

    [EnableCors("AnotherCorsPolicy")]
    [HttpGet("anotherPolicyExample")]
    public IActionResult GetTempAboveLimit()
    {
        return Ok("This action is protected with another named CORS policy");
    }
}
