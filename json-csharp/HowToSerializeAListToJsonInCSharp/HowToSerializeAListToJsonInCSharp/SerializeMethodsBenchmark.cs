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
        public void UseTheSerializeObjectMethod()
            => _serializeWithNewtonsoftJson.UseTheSerializeObjectMethod();

        [Benchmark]
        public void UseTheJsonSerializerClass()
            => _serializeWithNewtonsoftJson.UseTheJsonSerializerClass();

        [Benchmark]
        public void UseTheSerializeMethod()
            => _serializeWithSystemTextJson.UseTheSerializeMethod();

        [Benchmark]
        public void UseTheSerializeToUtf8BytesMethod()
            => _serializeWithSystemTextJson.UseTheSerializeToUtf8BytesMethod();
    }
}