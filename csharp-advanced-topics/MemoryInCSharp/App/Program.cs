using App;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<MemoryVsArrayBenchmarks>();
    }
}