using OrderPropertyJsonInCSharp.Converters;
using System.Text.Json.Serialization;

namespace OrderPropertyJsonInCSharp.Models
{
    [JsonConverter(typeof(MicrosoftOrderedPropertiesConverter<Animal>))]
    public class Animal
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Age { get; set; }
    }
}
