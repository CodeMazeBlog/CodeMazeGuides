using BenchmarkDotNet.Attributes;
using StaticVsNonStaticMethodsInCsharp;

namespace Benchmark
{
    [ShortRunJob]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    [MemoryDiagnoser]
    [MarkdownExporter]
    public class StaticVsNonStaticMethodsBenchmark
    {
        [Benchmark]
        public void Static()
        {
            StaticVsNonStaticMethods.StaticMehodForPerformanceTracking();
        }

        [Benchmark]
        public void NonStatic()
        {
            var staticVsNonStatic = new StaticVsNonStaticMethods();
            staticVsNonStatic.NonStaticMehodForPerformanceTracking();
        }
    }
}
