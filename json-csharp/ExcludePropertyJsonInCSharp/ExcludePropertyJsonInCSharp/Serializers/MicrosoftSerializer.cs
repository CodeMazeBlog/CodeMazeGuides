using ExcludePropertyJsonInCSharp.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExcludePropertyJsonInCSharp.Serializers
{
    public static class MicrosoftSerializer
    {
        public static string ExcludePropertyJsonIgnore(Person person)
        {
            var json = JsonSerializer.Serialize(person,
                new JsonSerializerOptions { WriteIndented = true }
            );

            return json;
        }

        public static string ExcludeAllNullProperties(Book book)
        {
            var json = JsonSerializer.Serialize(book,
                new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    WriteIndented = true
                });


            return json;
        }

        public static string ExcludeAllDefaultProperties(Book book)
        {
            var json = JsonSerializer.Serialize(book,
                new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    WriteIndented = true
                });

            return json;
        }
    }
}
