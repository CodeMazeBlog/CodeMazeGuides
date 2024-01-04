using MessageTemplateForLoggingCA2254;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Bogus;
using System.Text.Json;
using Xunit;

namespace Tests;

public class ApplicationTests
{
    private readonly ILogger<Application> Logger;
    private readonly Faker Faker;
    public ApplicationTests()
    {
        Logger = Substitute.For<ILogger<Application>>();
        Faker = new Faker();
    }

    private Application GetApplication() => 
        new Application(Logger);

    [Fact]
    public void WhenSimpleLog_ThenShowUsernameAndTimeTest()
    {
        var app = GetApplication();
        var userName = Faker.Person.UserName;
        var loggedinTime = Faker.Date.Recent();

        app.SimpleLog(userName, loggedinTime);

        Logger.Received(1).Log(LogLevel.Information, $"User {userName} logged in at {loggedinTime}");
    }
    
    [Fact]
    public void WhenLogJson_ThenShowUsernameAndTimeAsJsonTest()
    {
        var app = GetApplication();
        var userName = Faker.Person.UserName;
        var loggedinTime = Faker.Date.Recent();

        var logEntry = new
        {
            EventId = "logged_in",
            Username = userName,
            Time = loggedinTime,
        };

        var message = JsonSerializer.Serialize(logEntry);

        app.LogJson(userName, loggedinTime);

        Logger.Received(1).Log(LogLevel.Information, message);
    }
}