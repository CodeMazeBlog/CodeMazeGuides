using BenchmarkDotNet.Running;

namespace HowToEfficientlyRandomizeAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ArrayBenchmarks>();
        }
    }
}