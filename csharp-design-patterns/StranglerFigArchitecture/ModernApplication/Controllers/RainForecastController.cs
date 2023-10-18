using Microsoft.AspNetCore.Mvc;

namespace ModernApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class RainForecastController : ControllerBase
{
    private readonly ILogger<RainForecastController> _logger;

    public RainForecastController(ILogger<RainForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<RainForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new RainForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.NextDouble()
        )).ToArray();
    }
}