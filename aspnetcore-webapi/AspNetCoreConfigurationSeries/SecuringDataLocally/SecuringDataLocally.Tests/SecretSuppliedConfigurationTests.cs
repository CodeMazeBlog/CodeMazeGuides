using Microsoft.Extensions.Configuration;
using ProjectConfigurationDemo.Models;
using Testcontainers.MsSql;

namespace SecuringDataLocally.Tests;

// The folder must still RUN once the secret is supplied. The connection string
// reaches the EF configuration provider through configuration, never through
// appsettings.json.
public class SecretSuppliedConfigurationTests : IAsyncLifetime
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

    [RequiresDockerFact]
    public void GivenTheSecretIsSupplied_WhenTheApplicationConfigurationIsBuilt_ThenTheEntityProviderLoads()
    {
        var manager = new ConfigurationManager();

        ((IConfigurationBuilder)manager)
            .AddJsonFile(ConnectionStringSourceTests.AppSettingsPath)
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:sqlConnection"] = _sqlServer.GetConnectionString()
            });

        manager.AddEntityConfiguration();

        var titleConfiguration = manager.GetSection("Pages:HomePage").Get<TitleConfiguration>();

        Assert.NotNull(titleConfiguration);
        Assert.Equal("Welcome to the ProjectConfigurationDemo Home Page", titleConfiguration.WelcomeMessage);
    }
}
