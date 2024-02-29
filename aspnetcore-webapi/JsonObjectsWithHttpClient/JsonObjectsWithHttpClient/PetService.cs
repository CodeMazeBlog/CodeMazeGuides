using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace JsonObjectsWithHttpClient
{
    public class PetService : IPetService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<PetDto> PostAsJson()
        {
            var petData = CreateArg();

            var response = await _httpClient.PostAsJsonAsync("https://petstore.swagger.io/v2/pet", petData);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdPet = JsonSerializer.Deserialize<PetDto>(content);

            return createdPet;
        }

        public async Task<PetDto> PostAsStringContent()
        {
            var petData = CreateArg();

            var pet = JsonSerializer.Serialize(petData);

            var request = new HttpRequestMessage(HttpMethod.Post, "https://petstore.swagger.io/v2/pet");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(pet, Encoding.UTF8);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdPet = JsonSerializer.Deserialize<PetDto>(content);

            return createdPet;
        }

        private PetDto CreateArg()
        {
            return new PetDto
            {
                Name = "German Shepherd",
                Status = "Available",
                Category = new PetCategory
                {
                    Name = "Canines"
                }
            };
        }
    }
}