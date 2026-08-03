using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HowToTurnCSharpObjectIntoJson.Converters
{
    public class GeneralDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString() ?? string.Empty, "G", new CultureInfo("en-US"));
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("G", new CultureInfo("en-US")));
        }
    }
}
