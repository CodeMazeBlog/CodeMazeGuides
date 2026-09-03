using Microsoft.Extensions.Configuration;
using ProjectConfigurationDemo.Models;
using Testcontainers.MsSql;

namespace CustomConfigurationProvider.Tests;

public class EFConfigurationProviderTests : IAsyncLifetime
{
    private const string SqlServerImage = "mcr.microsoft.com/mssql/server:2022-latest";

    private readonly MsSqlContainer _sqlServer = new MsSqlBuilder(SqlServerImage).Build();

    public async Task InitializeAsync()
    {
        if (DockerAvailability.IsAvailable || DockerAvailability.IsRequired)
            await _sqlServer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        if (DockerAvailability.IsAvailable || DockerAvailability.IsRequired)
            await _sqlServer.DisposeAsync();
    }

    private ConfigurationManager BuildConfiguration()
    {
        var manager = new ConfigurationManager();

        ((IConfigurationBuilder)manager).AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["ConnectionStrings:sqlConnection"] = _sqlServer.GetConnectionString()
        });

        manager.AddEntityConfiguration();

        return manager;
    }

    [RequiresDockerFact]
    public void GivenAnEmptyDatabase_WhenTheProviderLoads_ThenItSeedsAndServesTheDefaultValues()
    {
        var configuration = BuildConfiguration();

        Assert.Equal("Welcome to the ProjectConfigurationDemo Home Page",
            configuration["Pages:HomePage:WelcomeMessage"]);
        Assert.Equal("black", configuration["Pages:HomePage:Color"]);
        Assert.Equal("true", configuration["Pages:HomePage:UseRandomTitleColor"]);
    }

    // The second run is the one that used to be subtly broken: the seeding branch
    // built a case-insensitive dictionary and the ToDictionary branch did not, so
    // the demo passed on the first run and was case-sensitive on every run after.
    [RequiresDockerFact]
    public void GivenAnAlreadySeededDatabase_WhenTheProviderLoadsAgain_ThenKeyLookupStaysCaseInsensitive()
    {
        _ = BuildConfiguration();

        var secondRun = BuildConfiguration();

        Assert.Equal("black", secondRun["Pages:HomePage:Color"]);
        Assert.Equal("black", secondRun["pages:homepage:color"]);
        Assert.Equal("black", secondRun.GetSection("pages:homepage")["color"]);
    }

    [RequiresDockerFact]
    public void GivenTheProviderIsRegistered_WhenTheSectionIsBound_ThenTheOptionsClassIsPopulated()
    {
        var configuration = BuildConfiguration();

        var titleConfiguration = configuration.GetSection("Pages:HomePage").Get<TitleConfiguration>();

        Assert.NotNull(titleConfiguration);
        Assert.Equal("Welcome to the ProjectConfigurationDemo Home Page", titleConfiguration.WelcomeMessage);
        Assert.True(titleConfiguration.UseRandomTitleColor);
    }
}
