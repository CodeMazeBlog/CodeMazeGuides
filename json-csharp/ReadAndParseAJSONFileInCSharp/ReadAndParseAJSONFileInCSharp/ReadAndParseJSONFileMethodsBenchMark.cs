using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ReadAndParseAJSONFileInCSharp;

namespace ReadAndParseAJSONFileInCSharp
{
    [MemoryDiagnoser(false)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ReadAndParseJSONFileMethodsBenchMark
    {
        private static readonly string _jsonFile 
            =  @"../../../../../../../Data\MethodsBenchmark-json.json";
        
        [Benchmark]
        public void UseUserDefinedObjectWithNewtonsoftJson()
            => ReadAndParseJsonFileWithNewtonsoftJson.UseUserDefinedObjectWithNewtonsoftJson(_jsonFile);

        [Benchmark]
        public void UseJArrayParseInNewtonsoftJson()
            => ReadAndParseJsonFileWithNewtonsoftJson.UseJArrayParseInNewtonsoftJson(_jsonFile);

        [Benchmark]
        public void UseJsonTextReaderInNewtonsoftJson()
            => ReadAndParseJsonFileWithNewtonsoftJson.UseJsonTextReaderInNewtonsoftJson(_jsonFile);

        [Benchmark]
        public void UseStreamReaderWithSystemTextJson() 
            => ReadAndParseJsonFileWithSystemTextJson.UseStreamReaderWithSystemTextJson(_jsonFile);

        [Benchmark]
        public void UseFileReadAllTextWithSystemTextJson()
            => ReadAndParseJsonFileWithSystemTextJson.UseFileReadAllTextWithSystemTextJson(_jsonFile);
        
        [Benchmark]
        public void UseFileOpenReadWithSystemTextJson()
            => ReadAndParseJsonFileWithSystemTextJson.UseFileOpenReadTextWithSystemTextJson(_jsonFile);
    }
}