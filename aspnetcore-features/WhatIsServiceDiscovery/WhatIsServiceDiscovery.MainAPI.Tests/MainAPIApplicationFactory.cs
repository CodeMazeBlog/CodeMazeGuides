namespace WhatIsServiceDiscovery.MainAPI.Tests;

public class MainAPIApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Mock HttpClient for testing.
            services.RemoveAll<IHttpClientFactory>();
            services.AddSingleton<IHttpClientFactory, MockHttpClientFactory>();
        });
    }
}

public class MockHttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateClient(string name)
    {
        var handler = new MockHttpMessageHandler();
        return new HttpClient(handler);
    }
}

public class MockHttpMessageHandler : HttpMessageHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Mock the response from the HttpClient.
        return new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("Mocked response from shipping API"),
        };
    }
}
