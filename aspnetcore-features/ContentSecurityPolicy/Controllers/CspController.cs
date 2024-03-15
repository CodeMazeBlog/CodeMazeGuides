using Microsoft.AspNetCore.Mvc;

namespace ContentSecurityPolicySample.Controllers;

public class CspController : Controller
{
    private readonly ILogger<CspController> _logger;

    public CspController(ILogger<CspController> logger)
    {
        _logger = logger;
    }

    [HttpPost("csp-violations")]
    public IActionResult CSPReport([FromBody] CspViolation cspViolation)
    {
        _logger.LogWarning($"URI: {cspViolation.CspReport.DocumentUri}, Blocked: {cspViolation.CspReport.BlockedUri}");

        return Ok();
    }
}
