using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SerializeJsonFromPascalToCamelCase.Models;

namespace SerializeJsonFromPascalToCamelCase;

public class Program
{
    public static void Main(string[] args)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        var result = JsonConvert.SerializeObject(GetData(), settings);

        Console.WriteLine("Width and Length property in pascal case using JsonConvert DefaultSettings: {0}", result);

        //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        //{
        //    ContractResolver = new CamelCasePropertyNamesContractResolver()
        //};

        //var result = JsonConvert.SerializeObject(GetData());

        //Console.WriteLine("Json converted to camel case using JsonConvert DefaultSettings: {0}", result);

        var convertedUnit = FormatJson.ConvertToCamel(JObject.FromObject(GetData()));
        result = JsonConvert.SerializeObject(convertedUnit);

        Console.WriteLine("Json converted to camel case using CamelCasePropertyNamesContractResolver: {0}", result);
    }

    private static House GetData()
    {
        return new House
        {
            SizeInSqft = 1000,
            NoOfRooms = 2,
            OtherDetails = JObject.FromObject(new Measurement
            {
                Width = 50,
                Length = 100
            })
        };
    }
}