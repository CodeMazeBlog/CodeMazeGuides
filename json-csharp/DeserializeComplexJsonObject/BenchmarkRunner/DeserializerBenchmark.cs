using BenchmarkDotNet.Attributes;
using DeserializeComplexJSONObject;

namespace BenchmarkRunner
{
    public class DeserializerBenchmark
    {
        private readonly MicrosoftDeserializer _microsoftDeserializer;
        private readonly NewtonsoftDeserializer _newtonsoftDeserializer;

        private readonly string _veryBigJson;

        public DeserializerBenchmark()
        {
            _microsoftDeserializer = new();
            _newtonsoftDeserializer = new();

            _veryBigJson = ReadJsonFile();
        }

        private string ReadJsonFile()
        {
            using StreamReader reader = new(@$"{AppContext.BaseDirectory}\JsonFiles\VeryBigJson.json");
            return reader.ReadToEnd();
        }

        [Benchmark]
        public void DeserializeUsingGenericSystemTextJson()
        {
            _microsoftDeserializer.DeserializeUsingGenericSystemTextJson(_veryBigJson);
        }

        [Benchmark]
        public void DeserializeUsingSystemTextJson()
        {
            _microsoftDeserializer.DeserializeUsingSystemTextJson(_veryBigJson);
        }

        [Benchmark]
        public void DeserializeUsingGenericNewtonsoftJson()
        {
            _newtonsoftDeserializer.DeserializeUsingGenericNewtonsoftJson(_veryBigJson);
        }
    }
}