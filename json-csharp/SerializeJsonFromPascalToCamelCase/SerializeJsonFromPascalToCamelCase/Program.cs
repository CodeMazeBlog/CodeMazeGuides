
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SerializeJsonFromPascalToCamelCase;
using SerializeJsonFromPascalToCamelCase.Models;

var houseInput = new House
{
    SizeInSqft = 1000,
    NoOfRooms = 2,
    OtherDetails = JObject.FromObject(new Measurement
    {
        Width = 50,
        Length = 100
    })
};

var settings = new JsonSerializerSettings
{
    ContractResolver = new CamelCasePropertyNamesContractResolver()
};

var result = JsonConvert.SerializeObject(houseInput, settings);

Console.WriteLine("Width and Length property in pascal case using JsonConvert DefaultSettings: {0}", result);

//JsonConvert.DefaultSettings = () => new JsonSerializerSettings
//{
//    ContractResolver = new CamelCasePropertyNamesContractResolver()
//};

//var result = JsonConvert.SerializeObject(GetData());

//Console.WriteLine("Json converted to camel case using JsonConvert DefaultSettings: {0}", result);

var convertedUnit = FormatJson.ConvertToCamel(JObject.FromObject(houseInput));
result = JsonConvert.SerializeObject(convertedUnit);

Console.WriteLine("Json converted to camel case using CamelCasePropertyNamesContractResolver: {0}", result);