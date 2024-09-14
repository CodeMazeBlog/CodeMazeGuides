namespace HowToGetAnInstanceOfIServiceProvider.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Services;

[ApiController]
public abstract class CustomBaseController : ControllerBase
{
    protected IExampleService ExampleService => HttpContext.RequestServices.GetService<IExampleService>();  
}

public class ExampleController : CustomBaseController
{
    [HttpGet("/api/example/get-serviceprovider-within-api-controller")]
    public IActionResult GetIServiceProviderFromHttpContext()
    {
        var resolvedService = ExampleService;

        return Ok(resolvedService is not null);
    }
}