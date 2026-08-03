using System.Net;
using System.Text.Json;

namespace WireMockNet
{
    public class PlanetsService
    {
        private readonly HttpClient _httpClient;

        public PlanetsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Planet?> GetPlanetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"planets/{id}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Planet>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }
    }
}