using Microsoft.AspNetCore.Mvc;
using System;

namespace DependencyInjectionLifetimeScopes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly IMyDependency _dependency;
        public readonly IMyService _service;

        public ValuesController(IMyDependency dependency, IMyService service)
        {
            _dependency = dependency ?? throw new ArgumentNullException(nameof(dependency));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"Controller Dependency Instance: {_dependency.GetInstanceId()}" +
                $"{Environment.NewLine}" +
                $"Service    Dependency Instance: {_service.GetInstanceId()}");
        }
    }
}
