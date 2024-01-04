using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MessageTemplateForLoggingCA2254;
public class Application
{
    private readonly ILogger<Application> _logger;

    public Application(ILogger<Application> logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        const string userName = "John Doe";
        var loggedinTime = DateTime.Now;
        SimpleLog(userName, loggedinTime);
        LogJson(userName, loggedinTime);
    }

    public void LogJson(string userName, DateTime loggedinTime)
    {
        var logEntry = new
        {
            EventId = "logged_in",
            Username = userName,
            Time = loggedinTime,
        };

        var message = JsonSerializer.Serialize(logEntry);
        _logger.Log(LogLevel.Information, message);
    }

    public void SimpleLog(string userName, DateTime loggedinTime)
    {
        _logger.Log(LogLevel.Information, $"User {userName} logged in at {loggedinTime}");
    }
}
