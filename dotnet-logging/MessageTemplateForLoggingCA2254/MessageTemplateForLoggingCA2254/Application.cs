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
        SimpleLogWithCA2254(userName, loggedinTime);
        LogJson(userName, loggedinTime);
        LogMessageTemplateInCSharp(userName);
        LogMessageTemplateInCSharp2(userName);
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

    public void SimpleLogWithCA2254(string userName, DateTime loggedOnTime)
    {
        _logger.Log(LogLevel.Information, $"User {userName} logged on {loggedOnTime}");
    }
    
    public void SimpleLogWithFixedCA2254(string userName, DateTime loggedOnTime)
    {
        _logger.LogInformation("User {userName} logged on {loggedOnTime}", userName, loggedOnTime);
    }
    
    public void LogMessageTemplateInCSharp(string userName)
    {
        _logger.LogInformation("User '{userName}' added apples to the basket.", userName);
    }
    
    public void LogMessageTemplateInCSharp2(string randomSentence)
    {
        _logger.LogInformation("User '{name}' added apples to the basket.", randomSentence);
    }
}
