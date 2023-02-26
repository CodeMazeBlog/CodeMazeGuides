using System.Text.Json;

namespace ReadAndParseAJSONFileInCSharp
{
    public class ReadAndParseJsonFileWithSystemTextJson
    {
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public string SampleJsonFilePath { get; set; }

        public ReadAndParseJsonFileWithSystemTextJson(string sampleJsonFilePath)
        {
            SampleJsonFilePath = sampleJsonFilePath;
        }

        public List<Teacher> UseStreamReaderWithSystemTextJson()
        {
            using StreamReader streamReader = new(SampleJsonFilePath);
            var json = streamReader.ReadToEnd();
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json, _options);

            return teachers;
        }

        public List<Teacher> UseFileReadAllTextWithSystemTextJson()
        {
            var json = File.ReadAllText(SampleJsonFilePath);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json, _options);

            return teachers;
        }

        public List<Teacher> UseFileOpenReadTextWithSystemTextJson()
        {
            using FileStream json = File.OpenRead(SampleJsonFilePath);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json, _options);

            return teachers;
        }
    }
}