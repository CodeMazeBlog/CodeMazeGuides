using LoggingAPI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class LoggingAPITests
{
    [TestMethod]
    public void GivenLogger_ShouldLogInformation_WhenStudentIsCreated()
    {
        var provider = new InMemoryLoggerProvider();
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddProvider(provider));

        _ = new Student("John", "IT", factory.CreateLogger<Student>());

        Assert.AreEqual(
            "Information: LoggingAPI.Student: Name of student is John and his department is IT",
            provider.Messages.Single());
    }

    [TestMethod]
    public void GivenLoggerFactory_ShouldCreateLogger_WhenDepartmentIsCreated()
    {
        var provider = new InMemoryLoggerProvider();
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddProvider(provider));

        _ = new Department("IT", "Information Technology", factory);

        Assert.AreEqual(
            "Information: LoggingAPI.Department: Department is IT Information Technology",
            provider.Messages.Single());
    }

    [TestMethod]
    public void GivenMinimumLevelWarning_ShouldSkipInformation_WhenStudentIsCreated()
    {
        var provider = new InMemoryLoggerProvider();
        using ILoggerFactory factory = LoggerFactory.Create(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Warning);
            builder.AddProvider(provider);
        });

        _ = new Student("John", "IT", factory.CreateLogger<Student>());

        Assert.AreEqual(0, provider.Messages.Count);
    }

    [TestMethod]
    public void GivenHost_ShouldResolveTypedLogger_WhenStudentIsCreated()
    {
        var provider = new InMemoryLoggerProvider();

        HostApplicationBuilder builder = Host.CreateApplicationBuilder();
        builder.Logging.ClearProviders();
        builder.Logging.AddProvider(provider);

        using IHost host = builder.Build();

        ILogger<Student> logger = host.Services.GetRequiredService<ILogger<Student>>();
        _ = new Student("John", "IT", logger);

        Assert.AreEqual(
            "Information: LoggingAPI.Student: Name of student is John and his department is IT",
            provider.Messages.Single());
    }
}
