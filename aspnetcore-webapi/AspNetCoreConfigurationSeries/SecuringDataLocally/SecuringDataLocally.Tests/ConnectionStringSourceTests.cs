using Microsoft.Extensions.Configuration;

namespace SecuringDataLocally.Tests;

public class ConnectionStringSourceTests
{
    internal static string AppSettingsPath =>
        Path.Combine(AppContext.BaseDirectory, "appsettings.json");

    // The article's subject, asserted rather than described: the checked-in
    // appsettings.json carries no connection string at all, so the value has to come
    // from a user secret or an environment variable.
    [Fact]
    public void GivenTheShippedAppSettingsFile_WhenTheConnectionStringIsRead_ThenThereIsNone()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(AppSettingsPath)
            .Build();

        Assert.Null(configuration.GetConnectionString("sqlConnection"));
        Assert.Empty(configuration.GetSection("ConnectionStrings").GetChildren());
    }

    [Fact]
    public void GivenAConnectionStringSuppliedOutsideTheFile_WhenItIsAddedLast_ThenItIsTheValueTheAppReads()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(AppSettingsPath)
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:sqlConnection"] = "Server=from-a-secret;Database=CodeMazeCommerce"
            })
            .Build();

        Assert.Equal("Server=from-a-secret;Database=CodeMazeCommerce",
            configuration.GetConnectionString("sqlConnection"));
    }

    [Fact]
    public void GivenAnEnvironmentVariable_WhenTheDoubleUnderscoreSeparatorIsUsed_ThenItReachesTheConnectionStringsSection()
    {
        Environment.SetEnvironmentVariable(
            "ConnectionStrings__sqlConnection", "Server=from-an-environment-variable");
        try
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(AppSettingsPath)
                .AddEnvironmentVariables()
                .Build();

            Assert.Equal("Server=from-an-environment-variable",
                configuration.GetConnectionString("sqlConnection"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("ConnectionStrings__sqlConnection", null);
        }
    }
}
