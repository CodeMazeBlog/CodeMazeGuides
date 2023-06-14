using System.Text.Json;
using ValueObjects.ValueObjects;

namespace ValueObjects.Serialization;

public class EmailAddressConverter : System.Text.Json.Serialization.JsonConverter<EmailAddress>
{
    public override EmailAddress? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var address = reader.GetString();
        if (string.IsNullOrEmpty(address))
            return null;
        return new(address);
    }

    public override void Write(Utf8JsonWriter writer, EmailAddress value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Address);
    }
}