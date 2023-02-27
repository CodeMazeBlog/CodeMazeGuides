using ExcludePropertyJsonInCSharp.Models;
using ExcludePropertyJsonInCSharp.Resolvers;
using Newtonsoft.Json;

namespace ExcludePropertyJsonInCSharp.Serializers
{
    public static class NewtonsoftSerializer
    {
        public static void ExcludePropertyJsonIgnore(PersonNewtonsoft person)
        {
            var json = JsonConvert.SerializeObject(person,
                Formatting.Indented
            );

            Console.WriteLine(json);
        }

        public static void IncludePropertyDataContract(Customer customer)
        {
            var json = JsonConvert.SerializeObject(customer,
                Formatting.Indented
            );

            Console.WriteLine(json);
        }

        public static void ExcludeAllNullProperties(Book book)
        {
            var json = JsonConvert.SerializeObject(book, 
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            Console.WriteLine(json);
        }

        public static void ExcludeAllDefaultProperties(Book book)
        {
            var json = JsonConvert.SerializeObject(book,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            Console.WriteLine(json);
        }

        public static void ExcludeUsingContractResolver(Movie movie)
        {
            var json = JsonConvert.SerializeObject(movie,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new IgnorePropertiesResolver("Id", "Classification")
                });

            Console.WriteLine(json);
        }
    }
}
