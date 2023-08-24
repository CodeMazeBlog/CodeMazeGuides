using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerializeExceptions;

public class SimpleExceptionConverter : JsonConverter<Exception>
{
    public override Exception? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Exception value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString("Error", value.Message);
        writer.WriteString("Type", value.GetType().Name);

        if (value.InnerException is { } innerException)
        {
            writer.WritePropertyName("InnerException");
            Write(writer, innerException, options);
        }

        writer.WriteEndObject();
    }
}