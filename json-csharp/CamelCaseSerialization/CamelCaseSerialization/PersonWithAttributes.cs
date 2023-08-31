using System.Text.Json.Serialization;

namespace CamelCaseSerialization;

public class PersonWithAttributes
{
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }
    
    [JsonPropertyName("surname")]
    public string? Surname { get; set; }
    
    [JsonPropertyName("age")]
    public int? Age { get; set; }
    
    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }
}
