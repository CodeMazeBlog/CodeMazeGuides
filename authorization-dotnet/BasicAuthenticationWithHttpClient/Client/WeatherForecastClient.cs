using System.Net.Http.Headers;
using System.Text;

namespace Client;

public class WeatherForecastClient
{
    private readonly HttpClient _client;

    public WeatherForecastClient(HttpClient client, IConfiguration configuration)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://localhost:7003");                
        var basicAuthenticationUsername = configuration["BasicAuthenticationUsername"];
        var basicAuthenticationPassword = configuration["BasicAuthenticationPassword"];
        var basicAuthenticationValue = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{basicAuthenticationUsername}:{basicAuthenticationPassword}"));
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", basicAuthenticationValue);
    }
    public async Task<string> GetAsync() => await _client.GetStringAsync("weatherforecast");
}
