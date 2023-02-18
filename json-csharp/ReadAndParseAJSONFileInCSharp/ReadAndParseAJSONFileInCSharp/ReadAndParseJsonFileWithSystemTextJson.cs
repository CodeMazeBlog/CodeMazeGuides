using System.Text.Json;

namespace ReadAndParseAJSONFileInCSharp
{
    public class ReadAndParseJsonFileWithSystemTextJson
    {
        private const string _sampleJsonFile = "teachers-json.json";

        public static List<Teacher> UseStreamReaderWithSystemTextJson(string sampleJsonFile = _sampleJsonFile)
        {
            using StreamReader streamReader = new(sampleJsonFile);
            string json = streamReader.ReadToEnd();
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json);

            return teachers;
        }

        public static List<Teacher> UseFileReadAllTextWithSystemTextJson(string sampleJsonFile = _sampleJsonFile)
        {
            string json = File.ReadAllText(sampleJsonFile);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json);

            return teachers;
        }

        public static List<Teacher> UseFileOpenReadTextWithSystemTextJson(string sampleJsonFile = _sampleJsonFile)
        {
            FileStream json = File.OpenRead(sampleJsonFile);
            List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(json);

            return teachers;
        }
    }
}