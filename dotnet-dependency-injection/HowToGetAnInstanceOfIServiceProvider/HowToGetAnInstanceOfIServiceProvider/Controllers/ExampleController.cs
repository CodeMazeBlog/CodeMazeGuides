namespace HowToGetAnInstanceOfIServiceProvider.Controllers;

using Microsoft.AspNetCore.Mvc;
using Services;

[ApiController]
public class ExampleController : ControllerBase
{
    private IExampleService ExampleService => HttpContext.RequestServices.GetService<IExampleService>();

    [HttpGet("/api/example/get-serviceprovider-within-api-controller")]
    public IActionResult GetIServiceProviderFromHttpContext()
    {
        var resolvedService = ExampleService;

        return Ok(resolvedService is not null);
    }
}