using System.Text.Json;

namespace HowToSerializeAListToJsonInCSharp
{
    public class SerializeListToJsonWithSystemTextJson(List<Club> clubList)
    {
        private readonly JsonSerializerOptions _options
            = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

        public string SerializeMethod()
        {
            return JsonSerializer.Serialize(clubList, _options);
        }

        public string SerializeToUtf8BytesMethod()
        {
            var result = JsonSerializer.SerializeToUtf8Bytes(clubList, _options);

            return System.Text.Encoding.UTF8.GetString(result);
        }

        public async Task SerializeToStreamAsync(Stream stream)
        {
            await JsonSerializer.SerializeAsync(stream, clubList, _options);
        }
    }
}