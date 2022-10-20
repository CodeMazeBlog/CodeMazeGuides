using Microsoft.AspNetCore.Mvc;

namespace ActionAndFunc.Controllers;

[ApiController]
[Route("[controller]")]
public class RulesController : ControllerBase
{
    [HttpGet(Name = "RunRules")]
    public IActionResult GetNumberDetails(int number)
    {
        var ruleEngine = new RuleEngine();
        var validationResults = ruleEngine.ExecuteRules(number);
        return Ok(validationResults);
    }
}