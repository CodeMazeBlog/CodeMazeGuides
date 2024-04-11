using System.Net.Http.Json;
using System.Text.Json;

public class LatLongWithHttpClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;

    public LatLongWithHttpClient(IHttpClientFactory httpClientFactory, string apiKey)
    {
        _httpClientFactory = httpClientFactory;
        _apiKey = apiKey;
    }

    public async Task<string> GetLatLongWithHttpClient(string address)
    {
        var httpClient = _httpClientFactory.CreateClient("MapsClient");
        var relativeUri = $"maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";

        try
        {
            var response = await httpClient.GetAsync(relativeUri);
            response.EnsureSuccessStatusCode();
            var root = await response.Content.ReadFromJsonAsync<JsonElement>();
            var status = root.GetProperty("status").GetString();

            if (status == "OK")
            {
                var location = root.GetProperty("results")[0].GetProperty("geometry").GetProperty("location");
                double latitude = location.GetProperty("lat").GetDouble();
                double longitude = location.GetProperty("lng").GetDouble();

                return $"Address ({address}) is at {latitude}, {longitude}";
            }

            return $"Error retrieving coordinates: API returned '{status}'.";
        }
        catch (Exception ex)
        {
            return $"Error retrieving coordinates: {ex.Message}";
        }
    }
}