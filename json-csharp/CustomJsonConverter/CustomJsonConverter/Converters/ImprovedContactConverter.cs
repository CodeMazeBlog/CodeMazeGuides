using Newtonsoft.Json;

namespace CustomJsonConverter.Converters;

public class ImprovedContactConverter : JsonConverter<Contact>
{
    public override void WriteJson(JsonWriter writer, Contact? contact, JsonSerializer serializer)
    {
        if (contact is null) return;

        writer.WriteStartObject();

        writer.WritePropertyName(nameof(contact.Name));
        writer.WriteValue(contact.Name);

        writer.WritePropertyName(nameof(contact.Department));
        writer.WriteValue(contact.Department);

        writer.WriteEndObject();
    }

    public override Contact? ReadJson(JsonReader reader, Type objectType, Contact? existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override bool CanWrite => true;

    public override bool CanRead => false;
}