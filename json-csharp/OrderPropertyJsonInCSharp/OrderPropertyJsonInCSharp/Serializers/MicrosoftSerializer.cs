using System.Text.Json;

namespace OrderPropertyJsonInCSharp.Serializers
{
    public class MicrosoftSerializer
    {
        public static string Serialize<T>(T instance)
        {
            var json = JsonSerializer.Serialize(instance,
                new JsonSerializerOptions { WriteIndented = true }
            );

            return json;
        }
    }
}
