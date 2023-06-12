using log4net;
using Microsoft.AspNetCore.Mvc;

namespace StructuredLoggingUsingLog4Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogTestController : ControllerBase
    {
        private readonly ILog _logger;

        public LogTestController(ILog logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.Info("This is an informational log.");
            _logger.Error("This is an error log.");
            _logger.Info(new { id = 1, name = "John" });

            return Ok("Test success!");
        }
    }
}
