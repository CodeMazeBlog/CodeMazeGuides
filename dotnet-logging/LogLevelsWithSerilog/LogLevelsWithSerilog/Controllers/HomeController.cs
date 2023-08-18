using LogLevelsWithSerilog.Manager;
using Microsoft.AspNetCore.Mvc;

namespace LogLevelsWithSerilog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOrderManager orderManager)
        {
            _logger = logger;
            _orderManager = orderManager;
        }

        public IActionResult Index()
        {
            _orderManager.CreateOrder(1, 2);

            return View();
        }

        public IActionResult Logs()
        {
            _logger.LogTrace("Trace Log Message");
            _logger.LogDebug("Debug Log Message");
            _logger.LogInformation("Information Log Message");
            _logger.LogWarning("Warning Log Message");
            _logger.LogError("Error Log Message");
            _logger.LogCritical("LogCritical Log Message");

            return View("Index");
        }

        public IActionResult GenerateLog(string message, int logType)
        {
            switch (logType)
            {
                case (int)Serilog.Events.LogEventLevel.Verbose:
                    _logger.LogTrace("Trace Log :" + message); break;
                case (int)Serilog.Events.LogEventLevel.Debug:
                    _logger.LogDebug("Debug Log :" + message); break;
                case (int)Serilog.Events.LogEventLevel.Information:
                    _logger.LogInformation("Information Log :" + message); break;
                case (int)Serilog.Events.LogEventLevel.Warning:
                    _logger.LogWarning("Warning Log :" + message); break;
                case (int)Serilog.Events.LogEventLevel.Error:
                    _logger.LogError("Error Log :" + message); break;
                case (int)Serilog.Events.LogEventLevel.Fatal:
                    _logger.LogCritical("FATAL Log :" + message); break;
                default:
                    _logger.LogInformation("InvalidLogType :" + message); break;
            }

            return View("Index");
        }
    }
}