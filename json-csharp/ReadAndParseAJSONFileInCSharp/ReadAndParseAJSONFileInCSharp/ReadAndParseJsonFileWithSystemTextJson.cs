using System.Text.Json;

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
    }
}