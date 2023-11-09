using DeserializeComplexJSONObject.POCO;
using System.Text.Json;

namespace DeserializeComplexJSONObject
{
    public class MicrosoftDeserializer
    {
        public Company? DeserializeUsingGenericSystemTextJson(string json)
        {
            var company = JsonSerializer.Deserialize<Company>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return company;
        }

        public Company? DeserializeUsingSystemTextJson(string json)
        {
            var company = (Company?)JsonSerializer.Deserialize(json, typeof(Company), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return company;
        }
    }
}
