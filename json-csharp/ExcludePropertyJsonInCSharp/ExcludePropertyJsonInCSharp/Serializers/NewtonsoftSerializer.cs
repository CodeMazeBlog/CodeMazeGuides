using ExcludePropertyJsonInCSharp.Models;
using ExcludePropertyJsonInCSharp.Resolvers;
using Newtonsoft.Json;

namespace ExcludePropertyJsonInCSharp.Serializers
{
    public static class NewtonsoftSerializer
    {
        public static string ExcludePropertyJsonIgnore(PersonNewtonsoft person)
        {
            var json = JsonConvert.SerializeObject(person,
                Formatting.Indented
            );

            return json;
        }

        public static string IncludePropertyDataContract(Customer customer)
        {
            var json = JsonConvert.SerializeObject(customer,
                Formatting.Indented
            );

            return json;
        }

        public static string ExcludeAllNullProperties(Book book)
        {
            var json = JsonConvert.SerializeObject(book, 
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            return json;
        }

        public static string ExcludeAllDefaultProperties(Book book)
        {
            var json = JsonConvert.SerializeObject(book,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            return json;
        }

        public static string ExcludeUsingContractResolver(Movie movie)
        {
            var json = JsonConvert.SerializeObject(movie,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new IgnorePropertiesResolver("Id", "Classification")
                });

            return json;
        }
    }
}
