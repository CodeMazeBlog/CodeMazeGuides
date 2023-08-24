using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DependencyInjectionLifetimeScopes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ILogger _logger;
        public readonly IMyTransientService _myTransientService;
        public readonly IMyScopedService _myScopedService;
        public readonly IMySingletonService _mySingletonService;

        public ValuesController(
            IMyTransientService myTransientService,
            IMyScopedService myScopedService,
            IMySingletonService mySingletonService,
            ILogger<ValuesController> logger
            )
        {
            _logger = logger;
            _myTransientService = myTransientService ?? throw new ArgumentNullException(nameof(myTransientService));
            _myScopedService = myScopedService ?? throw new ArgumentNullException(nameof(myScopedService));
            _mySingletonService = mySingletonService ?? throw new ArgumentNullException(nameof(mySingletonService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Transient: " + _myTransientService.InstanceId);
            _logger.LogInformation("Scoped: " + _myScopedService.InstanceId);
            _logger.LogInformation("Singleton: " + _mySingletonService.InstanceId);

            return Ok();
        }
    }
}
