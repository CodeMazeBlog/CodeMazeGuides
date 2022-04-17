using DeserializeJsonToPocoClass.POCO;
using System.Text.Json;
using System.IO;
using NewtonsoftJson = Newtonsoft.Json;

namespace DeserializeJsonToPocoClass
{
    public class Program
    {
        public static Car DeserializedJsonCar { get; set; } = default!;
        public static Car NewtonsoftDeserializedJsonCar { get; set; } = default!;

        public static void Main()
        {
            // Read JSON file. This could also be a DB or API response.
            var jsonStr = File.ReadAllText("JSON/HondaCivic.json");

            // Deserialize to get an object of type Car
            DeserializedJsonCar = JsonSerializer.Deserialize<Car>(jsonStr)!;

            // Deserialize to get an object of type Car
            NewtonsoftDeserializedJsonCar = NewtonsoftJson.JsonConvert.DeserializeObject<Car>(jsonStr)!;
        }
    }
}