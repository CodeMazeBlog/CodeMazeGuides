using Microsoft.AspNetCore.Mvc;
using ReadingRequestBody.Models;
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

    [HttpPost("read-as-string")]
    public IActionResult ReadAsString()
    {
        using StreamReader reader = new(Request.Body);
        string requestBody = reader.ReadToEnd();

        return Ok($"Request Body As String: {requestBody}");
    }

    [HttpPost("read-as-string-multiple")]
    public IActionResult ReadAsStringMultiple()
    {
        using StreamReader reader = new(Request.Body);
        string requestBody = reader.ReadToEnd();

        using StreamReader readerSecond = new(Request.Body);
        string requestBodySecond = reader.ReadToEnd();

        return Ok($"First: {requestBody}, Second:{requestBodySecond}");
    }

    [HttpPost("read-multiple-enable-buffering")]
    public IActionResult ReadMultipleEnableBuffering()
    {
        Request.EnableBuffering();

        using StreamReader reader = new(Request.Body);
        string requestBody = reader.ReadToEnd();

        Request.Body.Position = 0;

        using StreamReader readerSecond = new(Request.Body);
        string requestBodySecond = reader.ReadToEnd();

        return Ok($"First: {requestBody}, Second:{requestBodySecond}");
    }

    [HttpPost("read-from-body")]
    public IActionResult ReadFromBody([FromBody] PersonItemDto model)
    {
        var message = $"Person Data => Name: {model.Name}, Age: {model.Age}";

        return Ok(message);
    }

    [HttpPost("read-from-attribute")]
    [ReadRequestBody]
    public IActionResult ReadFromAttribute()
    {
        string requestBody = Request.Headers["ReadRequestBodyAttribute"];
        var message = $"Request Body From Attribute : {requestBody}";

        return Ok(message);
    }

    [HttpPost("read-from-action-filter")]
    public IActionResult ReadFromActionFilter()
    {
        string requestBody = Request.Headers["ReadRequestBodyActionFilter"];
        var message = $"Request Body From Action Filter : {requestBody}";

        return Ok(message);
    }

    [HttpPost("read-from-middleware")]
    public IActionResult ReadFromMiddleware()
    {
        string requestBody = Request.Headers["RequestBodyMiddleware"];
        var message = $"Request Body From Middleware : {requestBody}";

        return Ok(message);
    }
}