using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OrderPropertyJsonInCSharp.Serializers
{
    public static class NewtonsoftSerializer
    {
        public static string Serialize<T>(T instance)
        {
            var json = JsonConvert.SerializeObject(instance,
                Formatting.Indented
            );

            return json;
        }

        public static string Serialize<T>(T instance, JsonConverter converter)
        {
            var json = JsonConvert.SerializeObject(instance,
                Formatting.Indented,
                converter
            );

            return json;
        }
        
        public static string Serialize<T>(T instance, IContractResolver contractResolver)
        {
            var json = JsonConvert.SerializeObject(instance,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = contractResolver
                }
            );

            return json;
        }
    }
}
