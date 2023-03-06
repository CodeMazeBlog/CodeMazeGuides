using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ReadAndParseAJSONFileInCSharp
{
    [MemoryDiagnoser(false)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ReadAndParseJSONFileMethodsBenchMark
    {
        private readonly ReadAndParseJsonFileWithNewtonsoftJson _readWithNewtonsoftJson
            = new(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.Parent.FullName, "Data", "MethodsBenchmark-json.json"));
        private readonly ReadAndParseJsonFileWithSystemTextJson _readWithSystemTextJson
            = new(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.Parent.FullName, "Data", "MethodsBenchmark-json.json"));

        [Benchmark]
        public void UseUserDefinedObjectWithNewtonsoftJson()
            => _readWithNewtonsoftJson.UseUserDefinedObjectWithNewtonsoftJson();

        [Benchmark]
        public void UseJArrayParseInNewtonsoftJson()
            => _readWithNewtonsoftJson.UseJArrayParseInNewtonsoftJson();

        [Benchmark]
        public void UseJsonTextReaderInNewtonsoftJson()
            => _readWithNewtonsoftJson.UseJsonTextReaderInNewtonsoftJson();

        [Benchmark]
        public void UseStreamReaderWithSystemTextJson() 
            => _readWithSystemTextJson.UseStreamReaderWithSystemTextJson();

        [Benchmark]
        public void UseFileReadAllTextWithSystemTextJson()
            => _readWithSystemTextJson.UseFileReadAllTextWithSystemTextJson();
        
        [Benchmark]
        public void UseFileOpenReadWithSystemTextJson()
            => _readWithSystemTextJson.UseFileOpenReadTextWithSystemTextJson();
    }
}