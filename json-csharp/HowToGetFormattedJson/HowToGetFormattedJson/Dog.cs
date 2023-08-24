using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HowToGetFormattedJson
{
    public class Dog
    {
        [JsonProperty(PropertyName = "id")]
        public string? Name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? Breed { get; set; }
        public int Age { get; set; }
        [JsonProperty(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public List<string>? FavoriteToys { get; set; }
        [JsonProperty(Order = -2)]
        public List<string>? FavoriteFoods { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
