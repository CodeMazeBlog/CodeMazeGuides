using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using SystemTextJson = JsonDeserializationDynamicObject.Native.GenreRatingFinder;
using NewtonsoftJson = JsonDeserializationDynamicObject.Newtonsoft.GenreRatingFinder;

namespace JsonDeserializationDynamicObject.Benchmark
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class Benchmarks
    {
        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark(Baseline = true)]
        public void SimpleWrite()
        {
                       
        }

        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark]
        public void PrettyWrite()
        {
            
        }

        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark]
        public void Utf8BytesWrite()
        {
            
        }

        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark]
        public void StreamWrite()
        {
            
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark(Baseline = true)]
        public void NewtonsoftSimpleWrite()
        {
            
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void NewtonsoftPrettyWrite()
        {
            
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void NewtonsoftUtf8BytesWrite()
        {
            
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void NewtonsoftStreamWrite()
        {
            
        }
    }
}