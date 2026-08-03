using BenchmarkDotNet.Running;

namespace AddValuesToArray.Benchmark;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<AddValuesToArrayBenchmark>();
    }
}
