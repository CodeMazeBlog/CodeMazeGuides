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
            if (jsonProperty != null)
            {
                var propertyName = jsonProperty.PropertyName;
                yield return propertyName;
            }
        }
    }

    public static IEnumerable<string> RetrievalUsingSerialization(object obj)
    {
        string json = JsonConvert.SerializeObject(obj);

        var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        foreach (var key in values.Keys)
        {
            yield return key;  
        }
    }
}
