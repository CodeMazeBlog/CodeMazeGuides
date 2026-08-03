using RestSharp;
using RestSharp.Authenticators;

namespace RestSharpBasicHttpAuthenticator;

public static class Program
{
    private const string baseUrl = "https://httpbin.org";

    public static async Task Main()
    {
        var options = new RestClientOptions(baseUrl)
        {
            Authenticator = new HttpBasicAuthenticator("user", "pass")
        };

        var client = new RestClient(options);

        var request = new RestRequest("/basic-auth/user/pass");
        var response = await client.ExecuteGetAsync(request);

        Console.WriteLine(response.StatusCode);
    }
}