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

        public async Task<AccessToken> AuthenticateAsync()
        {
            var token = RetrieveCachedToken();
            if (!string.IsNullOrWhiteSpace(token))
                return new() { Token = token };

            var result = await _httpClient.PostAsync("api/auth/login", GenerateBody());

            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadAsStringAsync();

            var deserializedToken = DeserializeResponse<AccessToken>(response);

            SetCacheToken(deserializedToken);

            return deserializedToken;
        }

        private StringContent GenerateBody()
        {
            var email = Environment.GetEnvironmentVariable("email");
            var password = Environment.GetEnvironmentVariable("password");

            var body = JsonSerializer.Serialize(new { email, password },
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return new StringContent(body, Encoding.UTF8, "application/json");
        }

        private void SetCacheToken(AccessToken deserializedToken)
        {
            //In a real-world application we should store the token in a cache service and set an TTL.
            Environment.SetEnvironmentVariable("token", deserializedToken.Token);
        }

        private string RetrieveCachedToken()
        {
            //In a real-world application, we should retrieve the token from a cache service.
            return Environment.GetEnvironmentVariable("token");
        } 

        public T DeserializeResponse<T>(string response)
        {
            return JsonSerializer.Deserialize<T>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
