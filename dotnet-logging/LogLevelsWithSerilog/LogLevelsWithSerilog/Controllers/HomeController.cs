using Microsoft.AspNetCore.Mvc;

namespace LogLevelsWithSerilog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private const string LogTemplate = "{logType} Log : {message}";

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogTrace("Trace Log Message");
        _logger.LogDebug("Debug Log Message");
        _logger.LogInformation("Information Log Message");
        _logger.LogWarning("Warning Log Message");
        _logger.LogError("Error Log Message");
        _logger.LogCritical("Critical Log Message");

        return View();
    }

    public IActionResult GenerateLog(string message, int logType)
    {
        var logTypeDesc = ((Serilog.Events.LogEventLevel)logType).ToString();
        switch (logType)
        {
            case (int)Serilog.Events.LogEventLevel.Verbose:
                _logger.LogTrace(LogTemplate, logTypeDesc, message); break;
            case (int)Serilog.Events.LogEventLevel.Debug:
                _logger.LogDebug(LogTemplate, logTypeDesc, message); break;
            case (int)Serilog.Events.LogEventLevel.Information:
                _logger.LogInformation(LogTemplate, logTypeDesc, message); break;
            case (int)Serilog.Events.LogEventLevel.Warning:
                _logger.LogWarning(LogTemplate, logTypeDesc, message); break;
            case (int)Serilog.Events.LogEventLevel.Error:
                _logger.LogError(LogTemplate, logTypeDesc, message); break;
            case (int)Serilog.Events.LogEventLevel.Fatal:
                _logger.LogCritical(LogTemplate, logTypeDesc, message); break;
            default:
                _logger.LogInformation("InvalidLogType : {message}", message); break;
        }

        return View("Index");
    }
}