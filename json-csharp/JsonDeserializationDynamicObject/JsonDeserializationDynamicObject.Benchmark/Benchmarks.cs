using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using SystemTextJson = JsonDeserializationDynamicObject.Native.GenreRatingFinder;
using NewtonsoftJson = JsonDeserializationDynamicObject.Newtonsoft.GenreRatingFinder;
using System.IO;

namespace JsonDeserializationDynamicObject.Benchmark
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [CategoriesColumn]
    public class Benchmarks
    {
        private static readonly string _json = File.ReadAllText("MovieStats.json");

        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark]
        public void SystemTextJsonAnonymousType()
        {
            SystemTextJson.UsingAnonymousType(_json);
        }

        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark(Baseline = true)]
        public void UsingJsonElement()
        {
            SystemTextJson.UsingJsonElement(_json);          
        }

        [BenchmarkCategory(nameof(SystemTextJson))]
        [Benchmark]
        public void UsingJsonObject()
        {
            SystemTextJson.UsingJsonObject(_json);
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void UsingDynamic()
        {
            NewtonsoftJson.UsingDynamic(_json);
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void UsingExpandoObject()
        {
            NewtonsoftJson.UsingExpandoObject(_json);
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void NewtonsoftJsonAnonymousType()
        {
            NewtonsoftJson.UsingAnonymousTypeWithDictionary(_json);
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void UsingJObject()
        {
            NewtonsoftJson.UsingJObject(_json);
        }

        [BenchmarkCategory(nameof(NewtonsoftJson))]
        [Benchmark]
        public void UsingJsonPath()
        {
            NewtonsoftJson.UsingJsonPath(_json);
        }
    }
}