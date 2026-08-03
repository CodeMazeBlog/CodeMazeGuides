using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Tests;

public class AppSettingsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public AppSettingsTests(WebApplicationFactory<Program> webApplicationFactory)
    {
        _client = webApplicationFactory.CreateClient();
    }

    [Fact]
    public async Task GivenAppSettings_WhenReadByIConfiguration_ThenProvidesSettingByKey()
    {
        var localized = await _client.GetStringAsync("config/formatting/islocalized");
        var precision = await _client.GetStringAsync("config/formatting/number/precision");

        Assert.Equal("false", localized);
        Assert.Equal("3", precision);
    }

    [Fact]
    public async Task GivenAppSettings_WhenReadSectionByIConfiguration_ThenProvidesGroupOfSettings()
    {
        var formatting = await _client.GetStringAsync("config/formatting");

        Assert.Equal("{\"localize\":false,\"number\":{\"format\":\"n2\",\"precision\":3}}", formatting);
    }

    [Fact]
    public async Task GivenAppSettings_WhenReadSectionByOptions_ThenProvidesGroupOfSettings()
    {
        var formatting = await _client.GetStringAsync("options/formatting");

        Assert.Equal("{\"localize\":false,\"number\":{\"format\":\"n2\",\"precision\":3}}", formatting);
    }

    [Fact]
    public void GivenAppSettings_WhenReadByConfigurationBuilder_ThenProvidesConfigWithoutDependency()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var precision = configuration.GetValue<int>("Formatting:Number:Precision");

        Assert.Equal(3, precision);
    }
}