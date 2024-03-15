using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;

namespace Tests;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
public class ReadConnectionStringTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;

    public ReadConnectionStringTests(WebApplicationFactory<Program> factory)
    {
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public void WhenSettingsInJsonFile_ThenConfigurationProviderIsAdded()
    {
        var builder = new ConfigurationBuilder();

        builder.AddJsonFile("appsettings.json");
        var configuration = builder.Build();

        Assert.NotNull(configuration);
        Assert.Contains(configuration.Providers, x => (x as JsonConfigurationProvider).Source.Path == "appsettings.json");
    }

    [Fact]
    public void WhenReadingFromConnectionStringsSection_ThenValueIsRead()
    {
        var builder = new ConfigurationBuilder();

        builder.AddJsonFile("appsettings.json");

        IConfiguration configuration = builder.Build();
        var connString = configuration.GetConnectionString("ProductsDb");

        Assert.Equal("Server=myServer;Database=products;Trusted_Connection=True;", connString);
    }

    [Fact]
    public void WhenReadingFromCustomSection_ThenValueIsReadThroughSection()
    {
        var builder = new ConfigurationBuilder();

        builder.AddJsonFile("appsettings2.json");

        IConfiguration configuration = builder.Build();

        var prodDb = configuration.GetSection("Modules:Products").GetConnectionString("Database");

        Assert.Equal("Server=myServer;Database=products;Trusted_Connection=True;", prodDb);
    }

    [Fact]
    public void WhenReadingFromCustomSection_ThenValueIsReadDirectly()
    {
        var builder = new ConfigurationBuilder();

        builder.AddJsonFile("appsettings2.json");

        var configuration = builder.Build();

        var prodDb = configuration["Modules:Users:Database"];

        Assert.Equal("Server=myServer;Database=users;Trusted_Connection=True;", prodDb);
    }

    [Fact]
    public void WhenReadingFromCustomSection_ThenValueIsReadWithGetValue()
    {
        var builder = new ConfigurationBuilder();

        builder.AddJsonFile("appsettings2.json");

        var configuration = builder.Build();

        var prodDb = configuration.GetValue<string>("Modules:Users:Database");

        Assert.Equal("Server=myServer;Database=users;Trusted_Connection=True;", prodDb);
    }

    [Fact]
    public void WhenSettingsEnvVars_ThenConfigurationProviderIsAdded()
    {
        var builder = new ConfigurationBuilder();

        builder.AddEnvironmentVariables();
        var configuration = builder.Build();

        Assert.NotNull(configuration);
        Assert.Contains(configuration.Providers, x => x is EnvironmentVariablesConfigurationProvider);
    }

    [Fact]
    public void WhenReadingFromEnvVars_ThenValueIsRead()
    {
        Environment.SetEnvironmentVariable("ConnectionStrings__ProductsDb", "Server=myServer;Database=products;Trusted_Connection=True;");

        var builder = new ConfigurationBuilder();

        builder.AddEnvironmentVariables();

        IConfiguration configuration = builder.Build();
        var connString = configuration.GetConnectionString("ProductsDb");

        Assert.Equal("Server=myServer;Database=products;Trusted_Connection=True;", connString);
    }

    [Fact]
    public async Task WhenUsingConfigurationInAspNet_ThenConfigurationIsInjectedInController()
    {
        var response = await _httpClient.GetAsync("/products");
        Assert.True(response.IsSuccessStatusCode);
    }
}