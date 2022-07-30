using BenchmarkDotNet.Running;

namespace SortDictionaryByValue.Benchmark;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<SortDictionaryByValueBenchMark>();
    }
}
