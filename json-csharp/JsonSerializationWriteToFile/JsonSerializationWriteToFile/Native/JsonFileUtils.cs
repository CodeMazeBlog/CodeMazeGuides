using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace JsonSerializationWriteToFile.Native;

public static class JsonFileUtils
{
    private static readonly JsonSerializerOptions _options 
        = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

    public static void SimpleWrite(object obj, string fileName)
    {
        var jsonString = JsonSerializer.Serialize(obj, _options);

        File.WriteAllText(fileName, jsonString);
    }

    public static void PrettyWrite(object obj, string fileName)
    {
        var options = new JsonSerializerOptions(_options) 
        { 
            WriteIndented = true 
        };
        var jsonString = JsonSerializer.Serialize(obj, options);

        File.WriteAllText(fileName, jsonString);
    }

    public static void Utf8BytesWrite(object obj, string fileName)
    {
        var utf8Bytes = JsonSerializer.SerializeToUtf8Bytes(obj, _options);

        File.WriteAllBytes(fileName, utf8Bytes);
    }

    public static void StreamWrite(object obj, string fileName)
    {
        using var fileStream = File.Create(fileName);
        using var utf8JsonWriter = new Utf8JsonWriter(fileStream);

        JsonSerializer.Serialize(utf8JsonWriter, obj, _options);
    }

    public static async Task StreamWriteAsync(object obj, string fileName)
    {
        await using var fileStream = File.Create(fileName);
        await using var utf8JsonWriter = new Utf8JsonWriter(fileStream);

        await JsonSerializer.SerializeAsync(fileStream, obj, _options);
    }

    public static void WriteDynamicJsonObject(JsonObject jsonObj, string fileName)
    {
        using var fileStream = File.Create(fileName);
        using var utf8JsonWriter = new Utf8JsonWriter(fileStream);

        jsonObj.WriteTo(utf8JsonWriter);
    }
}