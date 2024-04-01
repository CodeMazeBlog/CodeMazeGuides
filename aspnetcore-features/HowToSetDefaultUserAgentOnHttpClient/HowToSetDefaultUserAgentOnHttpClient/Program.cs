using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;

namespace HowToSetDefaultUserAgentOnHttpClient;
public class Program
{
    public static void Main(string[] args)
    {
        var host = BuildHost();

        var httpClientFactory = host.Services.GetService<IHttpClientFactory>();

        GetDefaultAgentOnHttpClient(httpClientFactory);

        SetUserAgentOnHttpRequestMessage("CodeMazeDesktopApp", "1.1");
    }

    public static IHost BuildHost()
    {
        var builder = new HostBuilder()
            .ConfigureServices(services =>
            {
                services.AddHttpClient("CodeMazeHttpClient", client =>
                {
                    var productHeaderValue = new ProductHeaderValue(name: "CodeMazeDesktopApp", version: "1.1");
                    var productInfoHeaderValue = new ProductInfoHeaderValue(productHeaderValue);

                    client.DefaultRequestHeaders.UserAgent.Add(productInfoHeaderValue);
                });
            });

        return builder.Build();
    }

    public static string GetDefaultAgentOnHttpClient(IHttpClientFactory httpClientFactory)
    { 
        var httpClient = httpClientFactory.CreateClient("CodeMazeHttpClient");

        return httpClient.DefaultRequestHeaders.UserAgent.ToString();
    }

    public static string SetUserAgentOnHttpRequestMessage(string productName, string productVersion)
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "/users/1234");

        var productHeaderValue = new ProductHeaderValue(name: productName, version: productVersion);
        var productInfoHeaderValue = new ProductInfoHeaderValue(product: productHeaderValue);

        httpRequestMessage.Headers.UserAgent.Add(productInfoHeaderValue);

        return httpRequestMessage.Headers.UserAgent.ToString();
    }
}