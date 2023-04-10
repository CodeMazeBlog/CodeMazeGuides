using System.Text.Json;

namespace HowToSerializeAListToJsonInCSharp
{
    public class SerializeListToJsonWithSystemTextJson
    {
        private readonly List<Club> _clubList;
        private readonly JsonSerializerOptions _options 
            = new() 
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

        public SerializeListToJsonWithSystemTextJson(List<Club> clubList)
        {
            _clubList = clubList;
        }

        public string SerializeMethod()
        {
            return JsonSerializer.Serialize(_clubList, _options);
        }

        public string SerializeToUtf8BytesMethod()
        {
            var result = JsonSerializer.SerializeToUtf8Bytes(_clubList, _options);
            
            return System.Text.Encoding.UTF8.GetString(result);
        }
    }
}