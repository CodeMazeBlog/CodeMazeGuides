using System.Text.Json;
using System.Text.Json.Nodes;

namespace ReadAndParseAJSONFileInCSharp
{
    public class ReadAndParseJsonFileWithSystemTextJson
    {
        private readonly string _sampleJsonFilePath;

        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ReadAndParseJsonFileWithSystemTextJson(string sampleJsonFilePath)
        {
            _sampleJsonFilePath = sampleJsonFilePath;
        }

        public List<Teacher> UseStreamReaderWithSystemTextJson()
        {
            using StreamReader streamReader = new(_sampleJsonFilePath);
            var json = streamReader.ReadToEnd();
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json, _options);

            return teachers;
        }

        public List<Teacher> UseFileReadAllTextWithSystemTextJson()
        {
            var json = File.ReadAllText(_sampleJsonFilePath);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json, _options);

            return teachers;
        }

        public List<Teacher> UseFileOpenReadTextWithSystemTextJson()
        {
            using FileStream json = File.OpenRead(_sampleJsonFilePath);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json, _options);

            return teachers;
        }

        public async Task<List<Teacher>> UseFileOpenReadAsyncWithSystemTextJson()
        {
            using FileStream json = File.OpenRead(_sampleJsonFilePath);
            List<Teacher> teachers = await JsonSerializer.DeserializeAsync<List<Teacher>>(json, _options);

            return teachers;
        }

        public JsonNode UseJsonNodeWithSystemTextJson()
        {
            var json = File.ReadAllText(_sampleJsonFilePath);
            JsonNode teachers = JsonNode.Parse(json);

            return teachers;
        }
    }
}