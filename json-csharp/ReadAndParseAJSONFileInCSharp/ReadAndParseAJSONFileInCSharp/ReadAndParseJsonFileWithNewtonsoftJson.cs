using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ReadAndParseAJSONFileInCSharp
{
    public class ReadAndParseJsonFileWithNewtonsoftJson
    {
        private const string _sampleJsonFile = @"../../../Data/teachers-json.json";

        public static List<Teacher> UseUserDefinedObjectWithNewtonsoftJson(string sampleJsonFile = _sampleJsonFile)
        {
            using StreamReader reader = new(sampleJsonFile);
            string json = reader.ReadToEnd();
            List<Teacher> teachers = JsonConvert.DeserializeObject<List<Teacher>>(json);

            return teachers;
        }

        public static List<Teacher> UseJArrayParseInNewtonsoftJson(string sampleJsonFile = _sampleJsonFile)
        {
            using StreamReader reader = new(sampleJsonFile);
            string json = reader.ReadToEnd();
            JArray jarray = JArray.Parse(json);
            List<Teacher> teachers = new();

            foreach (var item in jarray)
            {
                Teacher teacher = item.ToObject<Teacher>();
                teachers.Add(teacher);
            }

            return teachers;
        }

        public static List<Teacher> UseJsonTextReaderInNewtonsoftJson(string sampleJsonFile = _sampleJsonFile)
        {
            var serializer = new JsonSerializer();
            List<Teacher> teachers = new();
            using (var streamReader = new StreamReader(sampleJsonFile))
            using (var textReader = new JsonTextReader(streamReader))
            {
                teachers = serializer.Deserialize<List<Teacher>>(textReader);
            }

            return teachers;
        }
    }
}