using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonSerializationWriteToFile.Newtonsoft;

public static class JsonFileUtils
{
    private static readonly JsonSerializerSettings _options
        = new() { NullValueHandling = NullValueHandling.Ignore };

    public static void SimpleWrite(object obj, string fileName)
    {
        var jsonString = JsonConvert.SerializeObject(obj, _options);

        File.WriteAllText(fileName, jsonString);
    }

    public static void PrettyWrite(object obj, string fileName)
    {
        var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented, _options);

        File.WriteAllText(fileName, jsonString);
    }

    static byte[] SerializeToUtf8Bytes(object obj, JsonSerializerSettings options)
    {
        using var stream = new MemoryStream();
        using var streamWriter = new StreamWriter(stream);
        using var jsonWriter = new JsonTextWriter(streamWriter);

        JsonSerializer.CreateDefault(options).Serialize(jsonWriter, obj);

        jsonWriter.Flush();
        stream.Position = 0;
        return stream.ToArray();
    }

    public static void Utf8BytesWrite(object obj, string fileName)
    {
        var utf8Bytes = SerializeToUtf8Bytes(obj, _options);
        File.WriteAllBytes(fileName, utf8Bytes);
    }

    public static void StreamWrite(object obj, string fileName)
    {
        using var streamWriter = File.CreateText(fileName);
        using var jsonWriter = new JsonTextWriter(streamWriter);

        JsonSerializer.CreateDefault(_options).Serialize(jsonWriter, obj);
    }

    public static async Task StreamWriteAsync(object obj, string fileName)
    {
        await Task.Run(() => StreamWrite(obj, fileName));
    }

    public static void WriteDynamicJsonObject(JObject jsonObj, string fileName)
    {
        using var streamWriter = File.CreateText(fileName);
        using var jsonWriter = new JsonTextWriter(streamWriter);

        jsonObj.WriteTo(jsonWriter);
    }
}