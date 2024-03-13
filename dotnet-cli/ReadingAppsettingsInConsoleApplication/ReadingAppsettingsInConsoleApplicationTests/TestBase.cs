using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadingAppsettingsInConsoleApplication.Configurations.ConfigurationProviders.Abstracts;

namespace ReadingAppsettingsInConsoleApplicationTests;

public abstract class TestBase(IConfigurationsProvider configurationsProvider)
{
    protected static ServiceProvider ServiceProvider;
    protected static IConfigurationRoot Configuration;
    private readonly IConfigurationsProvider _sut = configurationsProvider;
    
    [Fact]
    public void WhenGivenConfiguration_ThenIsRetrievedValidSettings()
    {
        // Arrange
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "development");
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(
                string.IsNullOrWhiteSpace(environment) ? "appsettings.json" : $"appsettings.{environment}.json")
            .Build();

        ServiceProvider = new ServiceCollection()
            .AddSingleton<IConfiguration>(Configuration)
            .BuildServiceProvider();
        
        // Act
        var (message, number) = _sut.GetApplicationSettings(ServiceProvider);

        // Assert
        message.Should().Be("This message is written in appsettings.development.json");
        number.Should().Be(50);
    }
}