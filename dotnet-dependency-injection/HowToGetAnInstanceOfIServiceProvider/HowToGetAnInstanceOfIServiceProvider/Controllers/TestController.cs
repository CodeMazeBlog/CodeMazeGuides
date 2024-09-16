namespace HowToGetAnInstanceOfIServiceProvider.Controllers;

using Microsoft.AspNetCore.Mvc;

public class ExampleController : CustomBaseController
{
    [HttpGet("/api/example/get-serviceprovider-within-api-controller")]
    public IActionResult GetIServiceProviderFromHttpContext()
    {
        var resolvedService = ExampleService;

        return Ok(resolvedService is not null);
    }
}