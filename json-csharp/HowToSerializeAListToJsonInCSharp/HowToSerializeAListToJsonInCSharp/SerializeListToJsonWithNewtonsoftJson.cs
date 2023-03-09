using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace HowToSerializeAListToJsonInCSharp
{
    public class SerializeListToJsonWithNewtonsoftJson
    {
        private readonly List<Club> _clubList;
        private readonly JsonSerializerSettings _settings
            = new()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
            };

        public SerializeListToJsonWithNewtonsoftJson(List<Club> clubList)
        {
            _clubList = clubList;
        }

        public string SerializeObjectMethod()
        {
            return JsonConvert.SerializeObject(_clubList, _settings);
        }

        public string JsonSerializerClass()
        {
            var serializer = JsonSerializer.Create(_settings);
            var stringBuilder = new StringBuilder();
            using (var writer = new JsonTextWriter(new StringWriter(stringBuilder)))
            {
                serializer.Serialize(writer, _clubList);
            }

            return stringBuilder.ToString();
        }
    }
}