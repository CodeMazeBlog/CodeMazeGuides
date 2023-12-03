using Newtonsoft.Json;
using System.Reflection;

namespace RetrieveJSONProperty.Helper
{
    public static class JsonHelper
    {
        public static void RetrievalUsingReflection(object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                var jsonProperty = property.GetCustomAttribute<JsonPropertyAttribute>();

                if (jsonProperty != null)
                {
                    var propertyName = jsonProperty.PropertyName;
                    Console.WriteLine(propertyName);
                }
            }
        }

        public static void RetrievalUsingSerlization(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            foreach (var key in values.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {values[key]}");
            }
        }
    }
}
