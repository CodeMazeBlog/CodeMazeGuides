namespace HowToGetAnInstanceOfIServiceProvider.Controllers;

using Microsoft.AspNetCore.Mvc;
using Services;

[ApiController]
public abstract class CustomBaseController : ControllerBase
{
    protected IExampleService ExampleService => HttpContext.RequestServices.GetService<IExampleService>();
}