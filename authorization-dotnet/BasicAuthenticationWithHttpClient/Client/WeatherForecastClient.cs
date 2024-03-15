using System.Net.Http.Headers;
using System.Text;

namespace Client;

public class WeatherForecastClient
{
    private readonly HttpClient _httpClient;

    public WeatherForecastClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7003");                
        var basicAuthenticationUsername = configuration["BasicAuthenticationUsername"];
        var basicAuthenticationPassword = configuration["BasicAuthenticationPassword"];
        var basicAuthenticationValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{basicAuthenticationUsername}:{basicAuthenticationPassword}"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuthenticationValue);

    }

    public async Task<string> GetAsync() => await _httpClient.GetStringAsync("weatherforecast");
}
