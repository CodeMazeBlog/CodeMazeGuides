using Newtonsoft.Json;
using System.Globalization;

namespace HowToTurnCSharpObjectIntoJson.Converters
{
    public class GeneralDateTimeNewtonsoftConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var dataString = reader.Value as string;
            return DateTime.ParseExact(dataString ?? string.Empty, "G", new CultureInfo("en-US")); ;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var dateTimeValue = value as DateTime?;
            writer.WriteValue(dateTimeValue?.ToString("G", new CultureInfo("en-US")));
        }
    }
}