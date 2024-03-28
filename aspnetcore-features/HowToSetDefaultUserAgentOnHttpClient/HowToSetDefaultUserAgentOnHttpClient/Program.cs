using System.Net.Http.Headers;
namespace HowToSetDefaultUserAgentOnHttpClient;
public class Program
{
    public static void Main(string[] args)
    {
        SetUserAgentOnHttpRequestMessage("CodeMazeDesktopApp", "1.1");
        SetUserAgentAsDefaultHeaderOnHttpClient("CodeMazeDesktopApp", "1.1");
    }

    public static void SetUserAgentOnHttpRequestMessage(string productName, string productVersion)
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "/users/1234");

        var productHeaderValue = new ProductHeaderValue(name: productName, version: productVersion);
        var productInfoHeaderValue = new ProductInfoHeaderValue(product: productHeaderValue);

        httpRequestMessage.Headers.UserAgent.Add(productInfoHeaderValue);

        Console.WriteLine($"The User-Agent header is set with value {httpRequestMessage.Headers.UserAgent.First()}");
    }

    public static void SetUserAgentAsDefaultHeaderOnHttpClient(string productName, string productVersion)
    {
        using var httpClient = new HttpClient();

        var productHeaderValue = new ProductHeaderValue(name: productName, version: productVersion);
        var productInfoHeader = new ProductInfoHeaderValue(product: productHeaderValue);

        httpClient.DefaultRequestHeaders.UserAgent.Add(productInfoHeader);

        Console.WriteLine($"The User-Agent header is set with value {httpClient.DefaultRequestHeaders.UserAgent.First()}");
    }
}