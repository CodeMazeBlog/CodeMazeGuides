using BenchmarkDotNet.Running;

namespace AutomapperVsMapster.Benchmark;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<AutomapperVsMapsterBenchmark>();
    }
}