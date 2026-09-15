using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ReadAndParseAJSONFileInCSharp
{
    [MemoryDiagnoser(false)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ReadAndParseJSONFileMethodsBenchMark
    {
        private static readonly string _benchmarkJsonFilePath
            = Path.Combine(AppContext.BaseDirectory, "Data", "MethodsBenchmark-json.json");

        private readonly ReadAndParseJsonFileWithNewtonsoftJson _readWithNewtonsoftJson
            = new(_benchmarkJsonFilePath);
        private readonly ReadAndParseJsonFileWithSystemTextJson _readWithSystemTextJson
            = new(_benchmarkJsonFilePath);

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