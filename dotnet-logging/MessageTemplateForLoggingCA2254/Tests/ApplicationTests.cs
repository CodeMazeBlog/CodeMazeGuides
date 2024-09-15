using MessageTemplateForLoggingCA2254;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Text.Json;
using Xunit;

namespace Tests;

public class ApplicationTests
{
    private readonly ILogger<Application> _logger;
    private readonly string _userName;
    private readonly DateTime _loggedInTime;
    private readonly Guid _userId;

    public ApplicationTests()
    {
        _logger = Substitute.For<ILogger<Application>>();

        _userName = "John Wick";
        _loggedInTime = DateTime.UtcNow;
        _userId = Guid.NewGuid();
    }

    private Application GetApplication() => 
        new Application(_logger);

    [Fact]
    public void WhenLogMessageWithJson_ThenShowUsernameAndTimeAsJsonTest()
    {
        var app = GetApplication();
        var logEntry = new
        {
            EventId = "logged_in",
            Username = _userName,
            Time = _loggedInTime,
        };

        var message = JsonSerializer.Serialize(logEntry);

        app.LogMessageWithJson(_userName, _loggedInTime);

        _logger.Received(1).Log(
            LogLevel.Information,
            Arg.Any<EventId>(),
            Arg.Is<object>(o =>
                o.ToString()!.Contains(message)),
            Arg.Any<Exception>(),
            Arg.Any<Func<object, Exception?, string>>()
        );
    }

    [Fact]
    public void WhenLogMessageWithSamePlaceholderAndVariableName_ThenShowUsernameTest()
    {
        var app = GetApplication();
        app.LogMessageWithSamePlaceholderAndVariableName(_userName);

        _logger.Received(1).Log(
            LogLevel.Information,
            Arg.Any<EventId>(),
            Arg.Is<object>(o => o.ToString()!.Contains($"User '{_userName}' added apples to the basket.")),
            Arg.Any<Exception>(),
            Arg.Any<Func<object, Exception?, string>>()
        );
    }
    
    [Fact]
    public void WhenLogMessageWithoutFormatting_ThenShowUsernameAndTimeWithoutFormattingTest()
    {
        var app = GetApplication();
        app.LogMessageWithoutFormatting(_userId, _loggedInTime);

        _logger.Received(1).Log(
            LogLevel.Information,
            Arg.Any<EventId>(),
            Arg.Is<object>(o => o.ToString()!.Contains($"User {_userId} logged in at {_loggedInTime:MM/dd/yyyy HH:mm:ss}.")),
            Arg.Any<Exception>(),
            Arg.Any<Func<object, Exception?, string>>()
        );
    }
    
    [Fact]
    public void WhenLogMessageWithFormatting_ThenShowUsernameAndTimeWithFormattingTest()
    {
        var app = GetApplication();
        app.LogMessageWithFormatting(_userId, _loggedInTime);

        _logger.Received(1).Log(
            LogLevel.Information,
            Arg.Any<EventId>(),
            Arg.Is<object>(o => o.ToString()!.Contains($"User {_userId:N} logged in at {_loggedInTime:F}.")),
            Arg.Any<Exception>(),
            Arg.Any<Func<object, Exception?, string>>()
        );
    }
    
    [Fact]
    public void WhenLogMessageWithDifferentPlaceholderAndVariableName_ThenShowUsernameTest()
    {
        var app = GetApplication();
        app.LogMessageWithDifferentPlaceholderAndVariableName(_userName);

        _logger.Received(1).Log(
            LogLevel.Information,
            Arg.Any<EventId>(),
            Arg.Is<object>(o => o.ToString()!.Contains($"User '{_userName}' added apples to the basket.")),
            Arg.Any<Exception>(),
            Arg.Any<Func<object, Exception?, string>>()
        );
    }

    [Fact]
    public void WhenLogMessageWithCA2254Warning_ThenShowUsernameAndTimeTest()
    {
        var app = GetApplication();
        app.LogMessageWithCA2254Warning(_userName, _loggedInTime);

        _logger.Received(1).Log(
            LogLevel.Information,
            Arg.Any<EventId>(),
            Arg.Is<object>(o =>
                o.ToString()!.Contains($"User {_userName} logged on {_loggedInTime}")),
            Arg.Any<Exception>(),
            Arg.Any<Func<object, Exception?, string>>()
        );
    }
    
    [Fact]
    public void WhenLogMessageToFixCA2254Warning_ThenShowUsernameAndTimeTest()
    {
        var app = GetApplication();
        app.LogMessageToFixCA2254Warning(_userName, _loggedInTime);

        _logger.Received(1).Log(
            LogLevel.Information,
            Arg.Any<EventId>(),
            Arg.Is<object>(o => 
                o.ToString()!.Contains($"User {_userName} logged on {_loggedInTime:MM/dd/yyyy HH:mm:ss}")),
            Arg.Any<Exception>(),
            Arg.Any<Func<object, Exception?, string>>()
        );
    }
}