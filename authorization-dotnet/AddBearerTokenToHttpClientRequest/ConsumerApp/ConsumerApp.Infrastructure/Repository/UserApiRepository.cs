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

        public async Task CreateUserAsync(UserModel userModel, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await _httpClient.PostAsync("api/users", GenerateBody(userModel)); 

            result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            var result = await _httpClient.GetAsync("api/users");

            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadAsStringAsync();

            return DeserializeResult<IEnumerable<UserModel>>(response);
        }

        public async Task<UserModel> GetUserAsync(int userId)
        {
            var result = await _httpClient.GetAsync($"api/users/{userId}");

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
