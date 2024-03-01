using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace JsonObjectsWithHttpClient;

public class PetService : IPetService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public PetService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient("PetStoreAPI");
    }

    public async Task<PetDto> PostAsJson()
    {
        var petData = CreatePet();

        var response = await _httpClient.PostAsJsonAsync("", petData);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var createdPet = JsonSerializer.Deserialize<PetDto>(content);

        return createdPet;
    }

    public async Task<PetDto> PostAsStringContent()
    {
        var petData = CreatePet();

        var pet = JsonSerializer.Serialize(petData);

        var request = new HttpRequestMessage(HttpMethod.Post,"");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Content = new StringContent(pet, Encoding.UTF8);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var response = await _httpClient.SendAsync(request);
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