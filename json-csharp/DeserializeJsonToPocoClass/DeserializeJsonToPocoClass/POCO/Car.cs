using System.Text.Json.Serialization;

namespace DeserializeJsonToPocoClass.POCO
{
    public class Car
    {
        [JsonPropertyName("make")]
        public string Make { get; set; } = default!;
        [JsonPropertyName("model")]
        public string Model { get; set; } = default!;
        [JsonPropertyName("year")]
        public int Year { get; set; } = default!;
        [JsonPropertyName("features")]
        public IEnumerable<string> Features { get; set; } = default!;
    }
}
