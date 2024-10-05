namespace HowToGetAnInstanceOfIServiceProvider.Controllers;

using Microsoft.AspNetCore.Mvc;
using Services;

[ApiController]
public class ExampleController : ControllerBase
{
    [HttpGet("/api/example/get-serviceprovider-within-api-controller")]
    public IActionResult GetIServiceProviderFromHttpContext()
    {
        var resolvedService = HttpContext.RequestServices.GetService<IExampleService>();

        return Ok(resolvedService is not null);
    }
}