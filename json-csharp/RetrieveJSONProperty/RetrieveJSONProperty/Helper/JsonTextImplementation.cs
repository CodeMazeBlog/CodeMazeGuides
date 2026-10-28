using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
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

    public static string[] GetSerializedPropertyNames<T>(JsonSerializerOptions? options = null)
    {
        options ??= JsonSerializerOptions.Default;
        options.MakeReadOnly(populateMissingResolver: true);

        JsonTypeInfo typeInfo = options.GetTypeInfo(typeof(T));

        return typeInfo.Properties
            .Where(property => property.Get is not null || property.Set is not null)
            .Select(property => property.Name)
            .ToArray();
    }
}
