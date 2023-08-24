using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrderPropertyJsonInCSharp.Converters
{
    public class MicrosoftOrderedPropertiesConverter<T> : JsonConverter<T>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(T).IsAssignableFrom(typeToConvert);
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            var properties = typeof(T).GetProperties().OrderBy(p => p.Name).ToList();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(value);

                writer.WritePropertyName(property.Name);

                JsonSerializer.Serialize(writer, propertyValue, options);
            }

            writer.WriteEndObject();
        }
    }
}
