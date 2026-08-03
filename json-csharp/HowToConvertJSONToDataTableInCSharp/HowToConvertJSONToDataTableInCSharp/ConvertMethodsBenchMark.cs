using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace HowToConvertJSONToDataTableInCSharp
{
    [MemoryDiagnoser(false)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ConvertMethodsBenchMark
    {
        private static readonly string _sampleJson 
            = GenerateBenchmarkStudentJson.Generate10000StudentsJsonData();

        [Benchmark]
        public void UseNewtonsoftJson() => ConvertMethods.UseNewtonsoftJson(_sampleJson);

        [Benchmark]
        public void UseSystemTextJson() => ConvertMethods.UseSystemTextJson(_sampleJson);

        [Benchmark]
        public void ManuallyConvertJsonToDataTable() 
            => ConvertMethods.ManuallyConvertJsonToDataTable(_sampleJson);
    }
}