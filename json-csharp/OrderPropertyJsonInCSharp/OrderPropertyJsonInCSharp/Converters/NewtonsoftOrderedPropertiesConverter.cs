using Newtonsoft.Json;

namespace OrderPropertyJsonInCSharp.Converters
{
    public class NewtonsoftOrderedPropertiesConverter<T> : JsonConverter<T>
    {
        public override T? ReadJson(JsonReader reader, Type objectType, T? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (!hasExistingValue)
            {
                existingValue = Activator.CreateInstance<T>();
            }

            serializer.Populate(reader, existingValue!);

            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, T? value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            var properties = typeof(T).GetProperties().OrderBy(p => p.Name);

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(value);

                writer.WritePropertyName(property.Name);

                serializer.Serialize(writer, propertyValue);
            }

            writer.WriteEndObject();
        }
    }
}