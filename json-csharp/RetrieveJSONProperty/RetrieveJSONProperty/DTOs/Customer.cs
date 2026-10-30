using System.Text.Json.Serialization;

namespace RetrieveJSONProperty.DTOs;

public class Customer
{
    [JsonPropertyName("FirstName")]
    public string? Name { get; set; }

    [JsonIgnore]
    public string? Password { get; set; }

    public int Age { get; set; }
}
