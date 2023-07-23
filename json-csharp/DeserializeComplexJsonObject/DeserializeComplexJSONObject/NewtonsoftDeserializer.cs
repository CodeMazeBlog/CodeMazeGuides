using DeserializeComplexJSONObject.POCO;
using Newtonsoft.Json;

namespace DeserializeComplexJSONObject
{
    public class NewtonsoftDeserializer
    {
        public Company? DeserializeUsingGenericNewtonsoftJson(string json)
        {
            var company = JsonConvert.DeserializeObject<Company>(json);

            return company;
        }
    }
}
