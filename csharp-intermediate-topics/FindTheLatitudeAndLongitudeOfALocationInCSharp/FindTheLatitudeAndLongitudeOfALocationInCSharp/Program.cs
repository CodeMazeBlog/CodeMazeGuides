namespace FindTheLatitudeAndLongitudeOfALocation;
using Services;
using Microsoft.Extensions.Configuration;

public class Program
{
    static async Task Main(string[] args)
    {
        //both methods need these
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<Program>();
        var configuration = builder.Build();
        var apiKey = configuration["YOUR_API_KEY"];
        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("API key not found. Please make sure it's set in the environment variables.");
            return;
        }

        var address = "Fort Myers, Florida";

        // nuget method stuff
        var locationService = new GoogleLocationServiceWrapper(apiKey);
        var latLongWithNuGet = new LatLongWithNuGet(locationService);
        var coordinatesNuGet = latLongWithNuGet.GetLatLongWithNuGet(address);
        Console.WriteLine(coordinatesNuGet);

        //long version stuff
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://maps.googleapis.com/")
        };
        var latLongWithHttpClient = new LatLongWithHttpClient(httpClient, apiKey);
        var coordinatesHttpClient = await latLongWithHttpClient.GetLatLongWithHttpClient(address);
        Console.WriteLine(coordinatesHttpClient);
    }
}


