using System.Text.Json;

namespace SerializationDemo.Client.Serialization.Json
{
    public class JsonStringSerializer : IStringSerializer
    {
        private readonly JsonSerializerOptions _options;

        public JsonStringSerializer()
            : this(GetDefaultJsonSerializerOptions())
        {
        }

        public JsonStringSerializer(JsonSerializerOptions options)
            => _options = options;

        public T Deserialize<T>(string text)
            => JsonSerializer.Deserialize<T>(text, _options);

        public string Serialize(object data)
            => JsonSerializer.Serialize(data, _options);

        private static JsonSerializerOptions GetDefaultJsonSerializerOptions()
            => new JsonSerializerOptions(JsonSerializerDefaults.Web);
    }
}