using Microsoft.AspNetCore.Mvc;

namespace RollingFileLoggingWithSerilog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("TESTING MESSAGE 123..");

            return View();
        }
    }
}