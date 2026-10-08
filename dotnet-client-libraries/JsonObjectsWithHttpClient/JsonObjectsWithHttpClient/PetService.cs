using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace JsonObjectsWithHttpClient;

public class PetService(HttpClient httpClient) : IPetService
{
    public async Task<PetDto?> PostAsStringContentAsync()
    {
        var petData = CreatePet();

        var pet = JsonSerializer.Serialize(petData);

        var request = new HttpRequestMessage(HttpMethod.Post, "pet");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Content = new StringContent(pet, Encoding.UTF8, "application/json");

        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PetDto>();
    }

    public async Task<PetDto?> PostWithPostAsJsonAsync()
    {
        var petData = CreatePet();

        var response = await httpClient.PostAsJsonAsync("pet", petData);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PetDto>();
    }

    public async Task<PetDto?> PostAsJsonContentAsync()
    {
        var petData = CreatePet();

        using var content = JsonContent.Create(petData);
        var response = await httpClient.PostAsync("pet", content);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<PetDto>();
    }

    public async Task<PetDto?> PostAsSourceGeneratedJsonAsync()
    {
        var petData = CreatePet();

        var response = await httpClient.PostAsJsonAsync("pet", petData, PetContext.Default.PetDto);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync(PetContext.Default.PetDto);
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