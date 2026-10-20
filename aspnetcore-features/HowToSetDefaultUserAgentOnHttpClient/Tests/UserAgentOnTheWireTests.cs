using HowToSetDefaultUserAgentOnHttpClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace Tests;

public class UserAgentOnTheWireTests : IAsyncLifetime
{
    private WebApplication _app = null!;
    private string _baseAddress = null!;

    public async Task InitializeAsync()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseUrls("http://127.0.0.1:0");

        _app = builder.Build();
        _app.MapGet("/user-agent", (HttpRequest request) => request.Headers.UserAgent.ToString());

        await _app.StartAsync();
        _baseAddress = _app.Urls.First();
    }

    public async Task DisposeAsync() => await _app.DisposeAsync();

    [Fact]
    public async Task WhenPlainHttpClientCallsTheServer_ThenNoUserAgentArrives()
    {
        using var httpClient = new HttpClient();

        var userAgent = await httpClient.GetStringAsync($"{_baseAddress}/user-agent");

        Assert.Equal(string.Empty, userAgent);
    }

    [Fact]
    public async Task WhenNamedClientCallsTheServer_ThenServerReadsTheDefaultUserAgent()
    {
        var httpClientFactory = Program.BuildHost().Services.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient("CodeMazeHttpClient");

        var userAgent = await httpClient.GetStringAsync($"{_baseAddress}/user-agent");

        Assert.Equal("CodeMazeDesktopApp/1.1", userAgent);
    }

    [Fact]
    public async Task WhenRequestSetsItsOwnUserAgent_ThenItReplacesTheDefault()
    {
        var httpClientFactory = Program.BuildHost().Services.GetRequiredService<IHttpClientFactory>();
        var httpClient = httpClientFactory.CreateClient("CodeMazeHttpClient");

        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseAddress}/user-agent");
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("CodeMazeReportJob", "2.0"));

        var response = await httpClient.SendAsync(request);
        var userAgent = await response.Content.ReadAsStringAsync();

        Assert.Equal("CodeMazeReportJob/2.0", userAgent);
    }
}
