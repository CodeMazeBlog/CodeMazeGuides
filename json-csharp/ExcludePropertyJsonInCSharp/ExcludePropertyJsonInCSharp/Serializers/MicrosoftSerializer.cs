using ExcludePropertyJsonInCSharp.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExcludePropertyJsonInCSharp.Serializers
{
    public static class MicrosoftSerializer
    {
        public static void ExcludePropertyJsonIgnore(Person person)
        {
            var json = JsonSerializer.Serialize(person,
                new JsonSerializerOptions { WriteIndented = true }
            );

            Console.WriteLine(json);
        }

        public static void ExcludeAllNullProperties(Book book)
        {
            var json = JsonSerializer.Serialize(book,
                new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    WriteIndented = true
                });


            Console.WriteLine(json);
        }

        public static void ExcludeAllDefaultProperties(Book book)
        {
            var json = JsonSerializer.Serialize(book,
                new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                    WriteIndented = true
                });

            Console.WriteLine(json);
        }
    }
}
