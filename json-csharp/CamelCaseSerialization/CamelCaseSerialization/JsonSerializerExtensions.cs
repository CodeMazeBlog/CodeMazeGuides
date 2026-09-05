using System.Text.Json;

namespace CamelCaseSerialization;

public static class JsonSerializerExtensions
{
    private static readonly JsonSerializerOptions CamelCaseOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static string SerializeWithCamelCase<T>(this T data) =>
        JsonSerializer.Serialize(data, CamelCaseOptions);

    public static T? DeserializeFromCamelCase<T>(this string json) =>
        JsonSerializer.Deserialize<T>(json, CamelCaseOptions);
}
