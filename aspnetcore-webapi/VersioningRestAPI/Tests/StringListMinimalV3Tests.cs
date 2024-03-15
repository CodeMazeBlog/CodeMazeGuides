using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
namespace Tests;

public class StringListMinimalV3Tests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;

    public StringListMinimalV3Tests(WebApplicationFactory<Program> factory)
    {
        const string serviceUrl = "https://localhost:7114/";
        _httpClient = factory.CreateClient();
        _httpClient.BaseAddress = new Uri(serviceUrl);
    }

    [Fact]
    public async Task GivenURLChange_WhenCalledV3_ThenReturnStringStartingWithC()
    {
        var json = await _httpClient.GetStringAsync("/api/minimal/v3/StringList");
        var strings = JArray.Parse(json);

        Assert.Equal(2, strings.Count);
        Assert.StartsWith("C", (string?)strings[0]);
        Assert.StartsWith("C", (string?)strings[1]);
    }
}