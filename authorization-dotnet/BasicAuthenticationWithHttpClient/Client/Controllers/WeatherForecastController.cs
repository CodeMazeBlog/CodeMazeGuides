using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly WeatherForecastClient _client;

    public WeatherForecastController(WeatherForecastClient client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _client.GetAsync();
        
        return Content(response, "application/json");
    }
}