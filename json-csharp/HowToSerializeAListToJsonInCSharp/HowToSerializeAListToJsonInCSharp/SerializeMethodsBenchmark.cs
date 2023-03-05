using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace HowToSerializeAListToJsonInCSharp
{
    [MemoryDiagnoser(false)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class SerializeMethodsBenchmark
    {
        private static readonly List<Club> _benchmarkLists
            = GenerateBenchmarkData.Generate10000ListsForBenchmark();
        private readonly SerializeListToJsonWithNewtonsoftJson _serializeWithNewtonsoftJson
            = new(_benchmarkLists);
        private readonly SerializeListToJsonWithSystemTextJson _serializeWithSystemTextJson
            = new(_benchmarkLists);

        [Benchmark]
        public void SerializeObjectMethod()
            => _serializeWithNewtonsoftJson.SerializeObjectMethod();

        [Benchmark]
        public void JsonSerializerClass()
            => _serializeWithNewtonsoftJson.JsonSerializerClass();

        [Benchmark]
        public void SerializeMethod()
            => _serializeWithSystemTextJson.SerializeMethod();

        [Benchmark]
        public void SerializeToUtf8BytesMethod()
            => _serializeWithSystemTextJson.SerializeToUtf8BytesMethod();
    }
}