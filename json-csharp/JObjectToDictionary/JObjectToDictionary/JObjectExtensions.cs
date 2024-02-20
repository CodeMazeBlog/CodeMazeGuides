using Newtonsoft.Json.Linq;

public static class JObjectExtensions
{
    public static Dictionary<string, object> ToDictionary(this JObject jObject)
    {
        Dictionary<string, object> result = new();

        foreach (var property in jObject.Properties())
        {
            string key = property.Name;
            JToken value = property.Value;

            result[key] = value?.ToObject<object>() ?? "";
        }

        return result;
    }
}