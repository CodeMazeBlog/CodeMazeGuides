using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using SystemTextJson = JsonSerializationWriteToFile.Native.JsonFileUtils;
using NewtonsoftJson = JsonSerializationWriteToFile.Newtonsoft.JsonFileUtils;

namespace JsonSerializationWriteToFile.Benchmark
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class Benchmarks
    {
        private readonly IEnumerable<College> _colleges = SurveyReport.GetColleges(500, 25, 3);

        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark(Baseline = true)]
        public void SimpleWrite()
        {
            SystemTextJson.SimpleWrite(_colleges, "simple.json");
        }

        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark]
        public void PrettyWrite()
        {
            SystemTextJson.PrettyWrite(_colleges, "pretty.json");
        }

        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark]
        public void Utf8BytesWrite()
        {
            SystemTextJson.Utf8BytesWrite(_colleges, "utf8bytes.json");
        }

        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark]
        public void StreamWrite()
        {
            SystemTextJson.StreamWrite(_colleges, "stream.json");
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark(Baseline = true)]
        public void NewtonsoftSimpleWrite()
        {
            NewtonsoftJson.SimpleWrite(_colleges, "newton-simple.json");
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void NewtonsoftPrettyWrite()
        {
            NewtonsoftJson.PrettyWrite(_colleges, "newton-pretty.json");
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void NewtonsoftUtf8BytesWrite()
        {
            NewtonsoftJson.Utf8BytesWrite(_colleges, "newton-utf8bytes.json");
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void NewtonsoftStreamWrite()
        {
            NewtonsoftJson.StreamWrite(_colleges, "newton-stream.json");
        }
    }
}