using ConsumerApp.Domain.Interfaces;
using ConsumerApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumerApp.Repository
{
    public class UserApiRepository : IUserApiRepository
    {
        private readonly HttpClient _httpClient;
        public UserApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task PostUsersAsync(UserModel userModel, string token)
        {
            var uri = new Uri("https://localhost:5001/api/users");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await _httpClient.PostAsync(uri, GenerateBody(userModel)); 

            result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var uri = new Uri("https://localhost:5001/api/users");

            var result = await _httpClient.GetAsync(uri);

            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadAsStringAsync();

            return DeserializeResult<IEnumerable<UserModel>>(response);
        }

        public async Task<UserModel> GetUsersAsync(int userId)
        {
            var uri = new Uri($"https://localhost:5001/api/users/{userId}");

            var result = await _httpClient.GetAsync(uri);

            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadAsStringAsync();

            return DeserializeResult<UserModel>(response);
        }

        private T DeserializeResult<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private HttpContent GenerateBody(object httpBody)
        {
            var body = JsonSerializer.Serialize(httpBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return new StringContent(body, Encoding.UTF8, "application/json");
        }
    }
}
