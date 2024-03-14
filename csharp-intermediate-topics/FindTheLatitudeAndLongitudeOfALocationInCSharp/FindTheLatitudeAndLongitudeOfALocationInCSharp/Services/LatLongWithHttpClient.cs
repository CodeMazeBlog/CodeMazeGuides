namespace Services;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

public class LatLongWithHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public LatLongWithHttpClient(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient;
        _apiKey = apiKey;
    }

    public async Task<string> GetLatLongWithHttpClient(string address)
    {
        var relativeUri = $"maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";

        try
        {
            var response = await _httpClient.GetAsync(relativeUri);
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
            else
            {
                return $"Error retrieving coordinates: API returned '{status}'.";
            }
        }
        catch (Exception ex)
        {
            return $"Error retrieving coordinates: {ex.Message}";
        }
    }
}