using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace HowToSerializeAListToJsonInCSharp
{
    public class SerializeListToJsonWithNewtonsoftJson(List<Club> clubList)
    {
        private readonly JsonSerializerSettings _settings
            = new()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
            };

        public string SerializeObjectMethod()
        {
            return JsonConvert.SerializeObject(clubList, _settings);
        }

        public string JsonSerializerClass()
        {
            var serializer = JsonSerializer.Create(_settings);
            var stringBuilder = new StringBuilder();
            using (var writer = new JsonTextWriter(new StringWriter(stringBuilder)))
            {
                serializer.Serialize(writer, clubList);
            }

            return stringBuilder.ToString();
        }
    }
}