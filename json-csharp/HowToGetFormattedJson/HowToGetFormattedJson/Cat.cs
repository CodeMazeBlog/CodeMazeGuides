using System.Text.Json;
using System.Text.Json.Serialization;

namespace HowToGetFormattedJson
{
    public class Cat
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public List<string> FavoriteToys { get; set; }
        public List<string> FavoriteFoods { get; set; }

        public override string ToString()
        {
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.WriteAsString,
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            return JsonSerializer.Serialize(this, options);
        }
    }
}
