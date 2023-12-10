using System.Text.Json.Serialization;
namespace RetrieveJSONProperty.DTOs;

public class Country
{
    [JsonPropertyName("Nm")]
    public string Name { get; set; }

    [JsonPropertyName("Cd")]
    public string Code { get; set; }

}