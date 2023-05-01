using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Metrics.NET.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MetricsController : ControllerBase
{
    [HttpGet("incoming")]
    public IActionResult IncomingHttpRequest()
    {
        return Ok("Incoming HTTP request");
    }

    [HttpGet("outgoing")]
    public async Task OutgoingHttpRequest()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://code-maze.com");
        response.EnsureSuccessStatusCode();
    }

    [HttpGet("exception")]
    public void Exception()
    {
        throw new Exception("Unexpected error occurred");
    }
}
