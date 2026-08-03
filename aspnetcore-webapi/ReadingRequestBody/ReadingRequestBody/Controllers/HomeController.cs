using Microsoft.AspNetCore.Mvc;
using ReadingRequestBody.Models;
using ReadingRequestBody.SwaggerUtils;
using ReadingRequestBody.Utils;

namespace ReadingRequestBody.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Web API is ready.");
    }

    [SwaggerEnableRawText]
    [HttpPost("read-as-string")]
    public async Task<IActionResult> ReadAsString()
    {
        var requestBody = await Request.Body.ReadAsStringAsync();

        return Ok($"Request Body As String: {requestBody}");
    }

    [SwaggerEnableRawText]
    [HttpPost("read-as-string-multiple")]
    public async Task<IActionResult> ReadAsStringMultiple()
    {
        var requestBody = await Request.Body.ReadAsStringAsync();
        var requestBodySecond = await Request.Body.ReadAsStringAsync();

        return Ok($"First: {requestBody}, Second:{requestBodySecond}");
    }

    [SwaggerEnableRawText]
    [HttpPost("read-multiple-enable-buffering")]
    public async Task<IActionResult> ReadMultipleEnableBuffering()
    {
        Request.EnableBuffering();
        var requestBody = await Request.Body.ReadAsStringAsync(true);

        Request.Body.Position = 0;
        var requestBodySecond = await Request.Body.ReadAsStringAsync();

        return Ok($"First: {requestBody}, Second:{requestBodySecond}");
    }

    [HttpPost("read-from-body")]
    public IActionResult ReadFromBody([FromBody] PersonItemDto model)
    {
        var message = $"Person Data => Name: {model.Name}, Age: {model.Age}";

        return Ok(message);
    }

    [SwaggerEnableRawText]
    [HttpPost("read-from-attribute")]
    [ReadRequestBody]
    public IActionResult ReadFromAttribute()
    {
        var requestBody = Request.Headers["ReadRequestBodyAttribute"];
        var message = $"Request Body From Attribute : {requestBody}";

        return Ok(message);
    }

    [SwaggerEnableRawText]
    [HttpPost("read-from-action-filter")]
    public IActionResult ReadFromActionFilter()
    {
        var requestBody = Request.Headers["ReadRequestBodyActionFilter"];
        var message = $"Request Body From Action Filter : {requestBody}";

        return Ok(message);
    }

    [SwaggerEnableRawText]
    [HttpPost("read-from-middleware")]
    public IActionResult ReadFromMiddleware()
    {
        var requestBody = Request.Headers["RequestBodyMiddleware"];
        var message = $"Request Body From Middleware : {requestBody}";

        return Ok(message);
    }
}