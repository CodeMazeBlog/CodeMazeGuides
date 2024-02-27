using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace JsonObjectsWithHttpClient.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase
{
    private static readonly HttpClient _httpClient = new HttpClient();

    [HttpPost]
    public async Task<PetDto> Post()
    {
        var petData = new PetDto
        {
            name = "German Shepherd",
            status = "Available",
            category = new Category
            {
                name = "Canines"
            }
        };

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
}