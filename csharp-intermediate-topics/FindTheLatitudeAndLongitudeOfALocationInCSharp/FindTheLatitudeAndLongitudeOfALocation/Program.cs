namespace FindTheLatitudeAndLongitudeOfALocation;
using Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .AddUserSecrets<Program>();
        var configuration = builder.Build();
        var apiKey = configuration["Secret:MyApiKey"];

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("API key not found.");

            return;
        }

        var address = "Miami, Florida";

        var locationService = new GoogleLocationServiceWrapper(apiKey);
        var latLongWithNuGet = new LatLongWithNuGet(locationService);
        var coordinatesNuGet = await latLongWithNuGet.GetLatLongWithNuGet(address); 

        Console.WriteLine(coordinatesNuGet);

        var services = new ServiceCollection();

        services.AddHttpClient("MapsClient", client =>
        {
            client.BaseAddress = new Uri("https://maps.googleapis.com/");
        });

        services.AddSingleton<LatLongWithHttpClient>(provider =>
            new LatLongWithHttpClient(provider.GetRequiredService<IHttpClientFactory>(), apiKey));

        var serviceProvider = services.BuildServiceProvider();
        var latLongWithHttpClient = serviceProvider.GetRequiredService<LatLongWithHttpClient>();
        var coordinatesHttpClient = await latLongWithHttpClient.GetLatLongFromAddressAsync(address);

        Console.WriteLine($"Address ({address}) is at {coordinatesHttpClient.Latitude}, {coordinatesHttpClient.Longitude}");
    }
}