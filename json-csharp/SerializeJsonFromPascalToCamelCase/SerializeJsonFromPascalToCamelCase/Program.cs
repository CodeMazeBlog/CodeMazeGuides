using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SerializeJsonFromPascalToCamelCase.Models;

namespace SerializeJsonFromPascalToCamelCase;

public class Program
{
    public static void Main(string[] args)
    {
        var unit1 = new House
        {
            SizeInSqft = 1000,
            NoOfRooms = 2,
            OtherDetails = JObject.FromObject(new Measurement
            {
                Width = 50,
                Length = 100
            })
        };


        //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        //{
        //    ContractResolver = new CamelCasePropertyNamesContractResolver()
        //};

        //Console.WriteLine("Json converted to camel case using JsonConvert DefaultSettings: {0}", JsonConvert.SerializeObject(unit1));

        var codeMazeEstate = JObject.FromObject(unit1);
        var result = FormatJson.ConvertToCamel(codeMazeEstate);

        Console.WriteLine("Json converted to camel case using CamelCasePropertyNamesContractResolver: {0}", JsonConvert.SerializeObject(result));
    }
}