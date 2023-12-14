using System.Reflection;
using System.Text.Json.Serialization;

namespace RetrieveJSONProperty.Helper;

public static class JsonTextImplementation
{
    public static string[] GetJsonPropertyNames(object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();
        string[] propertyNames = properties
            .Select(property =>
                property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? property.Name)
            .ToArray();

        return propertyNames;
    }
}