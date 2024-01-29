using Microsoft.AspNetCore.Mvc;

namespace ResolvingUnsuportedMediaTypeResponse;

[Route("api/[Controller]/[Action]")]
public class PrinterController : Controller
{
    [HttpPost]
    public IActionResult Print([FromBody] string data)
    {
        return Ok($"Recievd: {data}");
    }
        
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json", "text/plain")]
    public IActionResult PrintFromBody([FromBody] string data)
    {
        return Ok($"Received (FromBody): {data}");
    }

    [HttpPost]
    [Consumes("application/x-www-form-urlencoded", "application/xml")]
    [Produces("application/json", "text/plain")]
    public IActionResult PrintFromForm([FromForm] string data)
    {
        return Ok($"Received (FromForm): {data}");
    }

    [HttpPost]
    [ProducesResponseType(415, Type = typeof(string))]
    public IActionResult PrintFromBodyManualCheck([FromForm] string data)
    {
        if (!Request.ContentType.StartsWith("application/x-www-form-urlencoded"))
        {
            return UnsupportedMediaType(Request.ContentType, "application/x-www-form-urlencoded");
        }
        return Ok($"Received (FromBody): {data}");
    }

    [HttpPost]
    [ValidateMediaType("application/x-www-form-urlencoded")]
    public IActionResult PrintFromBodyAttributeValidation([FromForm] string data)
    {
        return Ok($"Received (FromForm): {data}");
    }

    private IActionResult UnsupportedMediaType(string receivedType, string expectedType)
    {
        Response.StatusCode = 415;
        Response.ContentType = "text/plain";
        return Content($"Unsupported Media Type. Received: {receivedType} Expected: {expectedType}");
    }
}
