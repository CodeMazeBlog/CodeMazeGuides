using System.Text.Json;
using System.Text.Json.Serialization;

namespace HowToGetFormattedJson
{
    public class Cat
    {
        [JsonPropertyName("id")]
        public string? Name { get; set; }
        [JsonIgnore]
        public string? Breed { get; set; }
        [JsonPropertyOrder(-2)]
        public int Age { get; set; }
        public List<string>? FavoriteToys { get; set; }
        public List<string>? FavoriteFoods { get; set; }

        public override string ToString()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                NumberHandling = JsonNumberHandling.WriteAsString,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            return JsonSerializer.Serialize(this, options);
        }
    }
}
