using Microsoft.Extensions.Configuration;
using ProjectConfigurationDemo.Models;

namespace ConfigurationBasics.Tests;

public class ReadingConfigurationTests
{
    private static IConfiguration BuildConfiguration() =>
        new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Logging:LogLevel:Default"] = "Information",
                ["Logging:LogLevel:Microsoft"] = "Warning",
                ["ConnectionStrings:sqlConnection"] = "Server=.;Database=CodeMazeCommerce;Trusted_Connection=True"
            })
            .Build();

    [Fact]
    public void GivenAConfiguration_WhenReadWithTheIndexer_ThenItReturnsTheValueAtThatKeyPath()
    {
        var configuration = BuildConfiguration();

        var logLevel = configuration["Logging:LogLevel:Default"];

        Assert.Equal("Information", logLevel);
    }

    [Fact]
    public void GivenAConfiguration_WhenReadWithGetValue_ThenItConvertsToTheRequestedType()
    {
        var configuration = BuildConfiguration();

        var logLevel = configuration.GetValue<string>("Logging:LogLevel:Default");

        Assert.Equal("Information", logLevel);
    }

    [Fact]
    public void GivenAConfiguration_WhenGetConnectionStringIsCalled_ThenItReadsTheConnectionStringsSection()
    {
        var configuration = BuildConfiguration();

        var connectionString = configuration.GetConnectionString("sqlConnection");

        Assert.Equal("Server=.;Database=CodeMazeCommerce;Trusted_Connection=True", connectionString);
    }

    [Fact]
    public void GivenAConfiguration_WhenBindIsCalled_ThenItPopulatesTheStronglyTypedObject()
    {
        var configuration = BuildConfiguration();
        var logLevelConfiguration = new LoggingLevelConfiguration();

        configuration.Bind("Logging:LogLevel", logLevelConfiguration);

        Assert.Equal("Information", logLevelConfiguration.Default);
    }

    [Fact]
    public void GivenAConfiguration_WhenAKeyIsMissing_ThenTheIndexerReturnsNullRatherThanThrowing()
    {
        var configuration = BuildConfiguration();

        var missing = configuration["Logging:LogLevel:NotThere"];

        Assert.Null(missing);
    }
}
