using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace SerializeJsonFromPascalToCamelCase;

public class FormatJson
{
    public static JObject ConvertToCamel(JObject jsonObject)
    {
        var settings = JsonSerializer.Create(new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });

        return JObject.FromObject(jsonObject.ToObject<ExpandoObject>()!, settings);
    }
}