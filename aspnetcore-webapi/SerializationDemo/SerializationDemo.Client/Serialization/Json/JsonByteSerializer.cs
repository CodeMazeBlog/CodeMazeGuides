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

        public T Deserialize<T>(byte[] buffer)
        {
            using var stream = new MemoryStream(buffer);           
            return JsonSerializer.Deserialize<T>(stream, _options);
        }

        public byte[] Serialize(object data)
        {
            return JsonSerializer.SerializeToUtf8Bytes(data, _options);
        }   

        private static JsonSerializerOptions GetDefaultJsonSerializerOptions()
            => new JsonSerializerOptions(JsonSerializerDefaults.Web);
    }
}
