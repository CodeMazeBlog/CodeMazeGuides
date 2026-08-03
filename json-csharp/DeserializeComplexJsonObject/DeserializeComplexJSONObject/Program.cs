using DeserializeComplexJSONObject.JsonFiles;

namespace DeserializeComplexJSONObject
{
    public class Program
    {
        private static readonly MicrosoftDeserializer _microsoftDeserializer = new();
        private static readonly NewtonsoftDeserializer _newtonsoftDeserializer = new();
        public static int OutputResult = 0;

        public static void Main(string[] args)
        {
            Console.WriteLine("-------------------- Deserializing complex JSON object");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("---------- Reading JSON file");
            var json = ReadJsonFile();

            Console.WriteLine();

            Console.WriteLine("---------- Deserialize using Generic System.Text.Json");
            var companyGenericSystemText = _microsoftDeserializer.DeserializeUsingGenericSystemTextJson(json);

            Console.WriteLine("---------- Deserialize using System.Text.Json");
            var companySystemText = _microsoftDeserializer.DeserializeUsingGenericSystemTextJson(json);

            Console.WriteLine();

            Console.WriteLine("---------- Deserialize using Newtonsoft.Json");
            var companyNewtonsoftJson = _newtonsoftDeserializer.DeserializeUsingGenericNewtonsoftJson(json);

            Console.WriteLine("End of execution");

            OutputResult = 1;
        }

        public static string ReadJsonFile()
        {
            return JsonComplexObject.Json;
        }
    }
}