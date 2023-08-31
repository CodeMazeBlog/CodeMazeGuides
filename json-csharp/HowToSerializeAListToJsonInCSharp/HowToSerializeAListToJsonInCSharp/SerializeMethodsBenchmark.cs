using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace HowToSerializeAListToJsonInCSharp
{
    [MemoryDiagnoser(false)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class SerializeMethodsBenchmark
    {
        private static readonly List<Club> _benchmarkList
            = GenerateBenchmarkData.Generate10000ListsForBenchmark();
        private readonly SerializeListToJsonWithNewtonsoftJson _serializeWithNewtonsoftJson
            = new(_benchmarkList);
        private readonly SerializeListToJsonWithSystemTextJson _serializeWithSystemTextJson
            = new(_benchmarkList);

        [Benchmark]
        public void NewtonsoftJsonSerializeObjectMethod()
            => _serializeWithNewtonsoftJson.SerializeObjectMethod();

        [Benchmark]
        public void NewtonsoftJsonJsonSerializerClass()
            => _serializeWithNewtonsoftJson.JsonSerializerClass();

        [Benchmark]
        public void SystemTextJsonSerializeMethod()
            => _serializeWithSystemTextJson.SerializeMethod();

        [Benchmark]
        public void SystemTextJsonSerializeToUtf8BytesMethod()
            => _serializeWithSystemTextJson.SerializeToUtf8BytesMethod();
    }
}