using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace OrderPropertyJsonInCSharp.Serializers
{
    public static class MicrosoftSerializer
    {
        public static string Serialize<T>(T instance)
        {
            var json = JsonSerializer.Serialize(instance,
                new JsonSerializerOptions { WriteIndented = true }
            );

            return json;
        }

        public static string Serialize<T>(T instance, JsonConverter<T> converter)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            options.Converters.Add(converter);

            var json = JsonSerializer.Serialize(instance, options);

            return json;
        }

        public static string Serialize<T>(T instance, DefaultJsonTypeInfoResolver resolver)
        {
            var json = JsonSerializer.Serialize(instance,
                new JsonSerializerOptions { WriteIndented = true, TypeInfoResolver = resolver }
            );

            return json;
        }
    }
}
