using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HowToGetFormattedJson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rex = new Dog
            {
                Name = "Rex",
                Breed = "German Shepherd",
                Age = 3,
                FavoriteToys = new List<string> { "Bone" },
                FavoriteFoods = new List<string> { "Beef", "Chicken" }
            };

            Console.WriteLine(rex);

            var felix = new Cat
            {
                Name = "Felix",
                Breed = "Bengal",
                Age = 1,
                FavoriteToys = new List<string> { "Wool Ball", "Electric Mouse" },
                FavoriteFoods = new List<string> { "Chicken", "Fish" }
            };

            Console.WriteLine(felix);
            
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            Console.WriteLine(JsonConvert.SerializeObject(rex));
            Console.WriteLine(JsonConvert.SerializeObject(felix));
        }
    }
}
