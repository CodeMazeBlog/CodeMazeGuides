using Microsoft.AspNetCore.Mvc;

namespace QueryParameterDescriptionInSwagger.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];


    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameters">Testing param</param>
    /// <returns></returns>
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get([FromQuery] Parameters parameters)
    {
        return Enumerable.Range(1, parameters.Limit).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    public record Parameters
    {
        /// <summary>
        /// Number of the weather forecast data we want to return in the response
        /// </summary>
        public int Limit { get; set; }
    }
}
