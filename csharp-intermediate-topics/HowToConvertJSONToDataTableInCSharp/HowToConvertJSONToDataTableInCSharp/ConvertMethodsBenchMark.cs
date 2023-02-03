using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using BenchmarkDotNet.Order;
using System.Text.RegularExpressions;

namespace HowToConvertJSONToDataTableInCSharp
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class ConvertMethodsBenchMark
    {
        private static readonly string _sampleJson = GenerateBenchmarkStudentJson.Generate10000StudentsJsonData();

        [Benchmark]
        public void UseNewtonsoftJson() => ConvertMethods.UseNewtonsoftJson(_sampleJson);

        [Benchmark]
        public void UseSystemTextJson() => ConvertMethods.UseSystemTextJson(_sampleJson);

        [Benchmark]
        public void ManuallyConvertJsonToDataTable() => ConvertMethods.ManuallyConvertJsonToDataTable(_sampleJson);
    }
}