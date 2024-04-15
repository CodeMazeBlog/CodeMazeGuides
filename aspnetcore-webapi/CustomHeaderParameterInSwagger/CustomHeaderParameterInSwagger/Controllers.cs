using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace GlobalHeaderParameterInSwagger;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet]
    [Description("Sample endpoint that requires a custom header for authentication")]
    public IActionResult Get(string test)
    {
        if (!HttpContext.Request.Headers.TryGetValue("X-Custom-Header", out var headerValue) || headerValue != "secret-key")
        {
            return Unauthorized("Invalid or missing X-Custom-Header");
        }

        return Ok("Successfully authenticated with custom header!");
    }

    [HttpPost]
    [Description("Another sample endpoint that requires a custom header for authentication")]
    public IActionResult Post()
    {
        if (!HttpContext.Request.Headers.TryGetValue("X-Custom-Header", out var headerValue) || headerValue != "secret-key")
        {
            return Unauthorized("Invalid or missing X-Custom-Header");
        }

        return Ok("Successfully authenticated with custom header!");
    }
}

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpPost]
    [Description("Another test endpoint in another controller that requires a custom header for authentication")]
    public IActionResult Post()
    {
        if (!HttpContext.Request.Headers.TryGetValue("X-Custom-Header", out var headerValue) || headerValue != "secret-key")
        {
            return Unauthorized("Invalid or missing X-Custom-Header");
        }

        return Ok("Successfully authenticated with custom header!");
    }
}
