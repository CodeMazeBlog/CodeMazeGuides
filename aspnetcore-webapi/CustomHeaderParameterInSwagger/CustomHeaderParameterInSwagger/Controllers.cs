using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalHeaderParameterInSwagger;

[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        if (!HttpContext.Request.Headers.TryGetValue("X-Custom-Header", out var headerValue) || headerValue != "secret-key")
        {
            return Unauthorized("Invalid or missing X-Custom-Header");
        }

        return Ok("Successfully authenticated with custom header!");
    }

    [HttpPost]
    public IActionResult Post()
    {
        if (!HttpContext.Request.Headers.TryGetValue("X-Custom-Header", out var headerValue) || headerValue != "secret-key")
        {
            return Unauthorized("Invalid or missing X-Custom-Header");
        }

        return Ok("Successfully authenticated with custom header!");
    }
}
