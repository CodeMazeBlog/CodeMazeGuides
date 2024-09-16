namespace HowToGetAnInstanceOfIServiceProvider.Controllers;

using HowToGetAnInstanceOfIServiceProvider.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public abstract class CustomBaseController : ControllerBase
{
    protected IExampleService ExampleService => HttpContext.RequestServices.GetService<IExampleService>();
}