using ConsumerApp.Domain.Interfaces;
using ConsumerApp.Domain.Model;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumerApp.Infrastructure
{
    public class LoginApiRepository : ILoginApiRepository
    {
        private readonly HttpClient _httpClient;

        public LoginApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AccessToken> AuthenticateAsync(string email, string password)
        {
            var uri = new Uri("https://localhost:5001/api/auth/login");

            var body = JsonSerializer.Serialize(new { email, password }, 
                new JsonSerializerOptions 
                { 
                    PropertyNameCaseInsensitive = true 
                });

            var result = await _httpClient.PostAsync(uri, new StringContent(body, Encoding.UTF8, "application/json"));

            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadAsStringAsync();

            return DeserializeResponse<AccessToken>(response);
        }

        public T DeserializeResponse<T>(string response)
        {
            return JsonSerializer.Deserialize<T>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
