using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OrderPropertyJsonInCSharp.Models
{
    public class Vehicle
    {
        [JsonPropertyOrder(-1)]
        [JsonProperty(Order = -2)]
        public int Id { get; set; }

        public string? Manufacturer { get; set; }
    }
}
