using BenchmarkRunner;

namespace BenchmarkRunner
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<ElementCopierBenchmark>();
        }
    }
}