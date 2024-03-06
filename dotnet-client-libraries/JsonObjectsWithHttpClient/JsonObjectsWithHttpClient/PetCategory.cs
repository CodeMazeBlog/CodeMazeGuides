using System.Text.Json.Serialization;

namespace JsonObjectsWithHttpClient;

public class PetCategory
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}