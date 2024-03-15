using Newtonsoft.Json;
using System.Reflection;

namespace RetrieveJSONProperty.Helper;

public static class JsonHelper
{
    public static IEnumerable<string> RetrievalUsingReflection(object obj)
    {
        foreach (var property in obj.GetType().GetProperties())
        {
            var jsonProperty = property.GetCustomAttribute<JsonPropertyAttribute>();
            var jsonPropertyName = jsonProperty?.PropertyName;

            yield return jsonPropertyName != null 
                ? jsonPropertyName 
                : property.Name;
        }
    }

    public static IEnumerable<string> RetrievalUsingSerialization(object obj)
    {
        string json = JsonConvert.SerializeObject(obj);

        var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        return values != null 
            ? values.Keys 
            : Enumerable.Empty<string>();
    }
}