using Newtonsoft.Json;

namespace CustomJsonConverter.Converters;

public class ContactConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Contact);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is not Contact contact)
            return;

        writer.WriteStartObject();

        writer.WritePropertyName(nameof(contact.Name));
        writer.WriteValue(contact.Name);

        writer.WritePropertyName(nameof(contact.Department));
        writer.WriteValue(contact.Department);

        writer.WriteEndObject();
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override bool CanWrite => true;

    public override bool CanRead => false;
}