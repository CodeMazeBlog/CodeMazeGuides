using log4net;
using Microsoft.AspNetCore.Mvc;

namespace Log4netAppenders.Controllers
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
            _logger.Debug("This is a debug log.");
            _logger.Info("This is an informational log.");
            _logger.Warn("This is a warning log.");
            _logger.Error("This is an error log.");

            return Ok("Test success!");
        }
    }
}
