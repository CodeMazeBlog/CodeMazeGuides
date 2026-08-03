using DeserializeJsonToPocoClass.POCO;
using System.Text.Json;
using NewtonsoftJson = Newtonsoft.Json;

namespace DeserializeJsonToPocoClass
{
    public class Program
    {
        public static Car DeserializedJsonCar { get; set; } = default!;
        public static Car NewtonsoftDeserializedJsonCar { get; set; } = default!;

        public static void Main()
        {
            var jsonStr = File.ReadAllText("JSON/HondaCivic.json");

            DeserializedJsonCar = JsonSerializer.Deserialize<Car>(jsonStr)!;

            NewtonsoftDeserializedJsonCar = NewtonsoftJson.JsonConvert.DeserializeObject<Car>(jsonStr)!;
        }
    }
}