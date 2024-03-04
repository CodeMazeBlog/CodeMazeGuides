using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace JsonObjectsWithHttpClient;

public class PetService : IPetService
{
    private readonly HttpClient _httpClient;

    public PetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PetDto?> PostAsStringContentAsync()
    {
        var petData = CreatePet();

        var pet = JsonSerializer.Serialize(petData);

        var request = new HttpRequestMessage(HttpMethod.Post, "pet");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Content = new StringContent(pet, Encoding.UTF8);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var createdPet = JsonSerializer.Deserialize<PetDto>(content);

        return createdPet;
    }
    
    public async Task<PetDto?> PostAsJsonAsync()
    {
        var petData = CreatePet();

        var response = await _httpClient.PostAsJsonAsync("pet", petData);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var createdPet = JsonSerializer.Deserialize<PetDto>(content);

        return createdPet;
    }

    private PetDto CreatePet()
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