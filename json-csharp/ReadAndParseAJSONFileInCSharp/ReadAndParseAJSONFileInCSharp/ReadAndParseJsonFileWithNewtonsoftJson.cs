using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ReadAndParseAJSONFileInCSharp
{
    public class ReadAndParseJsonFileWithNewtonsoftJson
    {
        private readonly string _sampleJsonFilePath;

        public ReadAndParseJsonFileWithNewtonsoftJson(string sampleJsonFilePath)
        {
            _sampleJsonFilePath = sampleJsonFilePath;
        }

        public List<Teacher> UseUserDefinedObjectWithNewtonsoftJson()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<Teacher> teachers = JsonConvert.DeserializeObject<List<Teacher>>(json);

            return teachers;
        }

        public List<Teacher> UseJArrayParseInNewtonsoftJson()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            var jarray = JArray.Parse(json);
            List<Teacher> teachers = new();

            foreach (var item in jarray)
            {
                Teacher teacher = item.ToObject<Teacher>();
                teachers.Add(teacher);
            }

            return teachers;
        }

        public List<Teacher> UseJsonTextReaderInNewtonsoftJson()
        {
            var serializer = new JsonSerializer();
            List<Teacher> teachers = new();
            using (var streamReader = new StreamReader(_sampleJsonFilePath))
            using (var textReader = new JsonTextReader(streamReader))
            {
                teachers = serializer.Deserialize<List<Teacher>>(textReader);
            }

            return teachers;
        }
    }
}