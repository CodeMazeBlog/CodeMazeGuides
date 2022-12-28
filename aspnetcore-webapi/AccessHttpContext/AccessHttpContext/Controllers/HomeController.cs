using Microsoft.AspNetCore.Mvc;

namespace AccessHttpContext.Controllers;

[Route("Example")]
[ApiController]
public class ExampleController : Controller
{
    public Task ExampleAsync()
    {
        var contentType = HttpContext.Request.ContentType ?? "text/plain";
        return HttpContext.Response.WriteAsync(contentType);
    }
}