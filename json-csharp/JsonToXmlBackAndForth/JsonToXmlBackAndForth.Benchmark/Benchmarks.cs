using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using SystemTextJson = JsonToXmlBackAndForth.Native.JsonXmlUtils;
using NewtonsoftJson = JsonToXmlBackAndForth.Newtonsoft.JsonXmlUtils;
using System.IO;

namespace JsonToXmlBackAndForth.Benchmark
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [CategoriesColumn]
    [GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByCategory)]
    public class Benchmarks
    {
        private static readonly string _json = MovieStats.Json;
        private static readonly string _xml = MovieStats.Xml;

        [BenchmarkCategory("JSON to XML")]
        [Benchmark(Baseline = true)]
        public void SystemTextJsonToXml()
        {
            SystemTextJson.JsonToXml(_json);          
        }

        [BenchmarkCategory("JSON to XML")]
        [Benchmark]
        public void NewtonsoftJsonToXml()
        {
            NewtonsoftJson.JsonToXml(_json);
        }

        [BenchmarkCategory("XML to JSON")]
        [Benchmark(Baseline = true)]
        public void SystemTextXmlToJson()
        {
            SystemTextJson.XmlToJson(_xml);
        }

        [BenchmarkCategory("XML to JSON")]
        [Benchmark]
        public void NewtonsoftXmlToJson()
        {
            NewtonsoftJson.XmlToJson(_xml);
        }
    }
}