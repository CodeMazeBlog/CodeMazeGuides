using System.Net.Http.Json;
using System.Text.Json;
using Models;

public class LatLongWithHttpClient : IMapLocationService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;

    public LatLongWithHttpClient(IHttpClientFactory httpClientFactory, string apiKey)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = apiKey;
    }

    public async Task<CustomMapPoint> GetLatLongFromAddressAsync(string address)
    {
        var httpClient = _httpClientFactory.CreateClient("MapsClient");
        var relativeUri = $"maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";

        var response = await httpClient.GetAsync(relativeUri);
        response.EnsureSuccessStatusCode();
        var root = await response.Content.ReadFromJsonAsync<JsonElement>();
        var status = root.GetProperty("status").GetString();

        if (status == "OK")
        {
            var location = root.GetProperty("results")[0].GetProperty("geometry").GetProperty("location");
            return new CustomMapPoint
            {
                Latitude = location.GetProperty("lat").GetDouble(),
                Longitude = location.GetProperty("lng").GetDouble()
            };
        }
        else
        {
            throw new Exception($"Error retrieving coordinates: '{status}'.");
        }
    }
}