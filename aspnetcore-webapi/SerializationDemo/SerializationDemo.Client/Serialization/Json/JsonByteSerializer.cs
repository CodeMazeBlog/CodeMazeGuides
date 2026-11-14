using System.Text.Json;

namespace SerializationDemo.Client.Serialization.Json
{
    public class JsonByteSerializer : IByteSerializer
    {
        private readonly JsonSerializerOptions _options;

        public JsonByteSerializer()
           : this(GetDefaultJsonSerializerOptions())
        {
        }

        public JsonByteSerializer(JsonSerializerOptions options)
           => _options = options;

        public T? Deserialize<T>(byte[] buffer)
            => JsonSerializer.Deserialize<T>(buffer, _options);

        public byte[] Serialize(object data)
            => JsonSerializer.SerializeToUtf8Bytes(data, _options);

        private static JsonSerializerOptions GetDefaultJsonSerializerOptions()
            => new JsonSerializerOptions(JsonSerializerDefaults.Web);
    }
}
