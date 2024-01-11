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
        var userName = "John Doe";
        var loggedinTime = DateTime.Now;
        LogMessageWithJson(userName, loggedinTime);
        LogMessageWithSamePlaceholderAndVariableName(userName);
        LogMessageWithDifferentPlaceholderAndVariableName(userName);
        LogMessageWithCA2254Warning(userName, loggedinTime);
        LogMessageToFixCA2254Warning(userName, loggedinTime);
    }

    public void LogMessageWithJson(string userName, DateTime loggedinTime)
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

    public void LogMessageWithSamePlaceholderAndVariableName(string userName)
    {
        _logger.LogInformation("User '{userName}' added apples to the basket.", userName);
    }
    
    public void LogMessageWithDifferentPlaceholderAndVariableName(string randomSentence)
    {
        _logger.LogInformation("User '{name}' added apples to the basket.", randomSentence);
    }
    
    public void LogMessageWithCA2254Warning(string userName, DateTime loggedOnTime)
    {
        _logger.Log(LogLevel.Information, $"User {userName} logged on {loggedOnTime}");
    }
    
    public void LogMessageToFixCA2254Warning(string userName, DateTime loggedOnTime)
    {
        _logger.LogInformation("User {userName} logged on {loggedOnTime}", userName, loggedOnTime);
    }
}
