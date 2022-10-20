using Microsoft.AspNetCore.Mvc;

namespace ActionAndFunc.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "RunRules")]
    public IActionResult Get()
    {
        var ruleEngine = new RuleEngine();
        var isPositiveNumnber = ruleEngine.Rules["PositiveNumber"](25);
        return Ok();
    }
}