namespace FindTheLatitudeAndLongitudeOfALocation;
using Services;
using Microsoft.Extensions.Configuration;

public class Program
{
    static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<Program>();
        var configuration = builder.Build();
        var apiKey = configuration["YOUR_API_KEY"];
        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("API key not found.");
            return;
        }

        var address = "Miami, Florida";
        var locationService = new GoogleLocationServiceWrapper(apiKey);
        var latLongWithNuGet = new LatLongWithNuGet(locationService);
        var coordinatesNuGet = latLongWithNuGet.GetLatLongWithNuGet(address);
        Console.WriteLine(coordinatesNuGet);

        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://maps.googleapis.com/")
        };
        var latLongWithHttpClient = new LatLongWithHttpClient(httpClient, apiKey);
        var coordinatesHttpClient = await latLongWithHttpClient.GetLatLongWithHttpClient(address);
        Console.WriteLine(coordinatesHttpClient);
    }
}


