using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerializeToDictionaryDataModel;

public sealed class CustomerKeyConverter : JsonConverter<Customer>
{
    public override Customer Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        // Since we are only dealing with Serializing in this article, we don't need to implement the Read method
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, Customer value, JsonSerializerOptions options)
        => writer.WriteStringValue($"Customer-{value.CustomerId:N}");

    public override void WriteAsPropertyName(Utf8JsonWriter writer, Customer value,
        JsonSerializerOptions options)
        => writer.WritePropertyName($"Customer-{value.CustomerId:N}");
}
