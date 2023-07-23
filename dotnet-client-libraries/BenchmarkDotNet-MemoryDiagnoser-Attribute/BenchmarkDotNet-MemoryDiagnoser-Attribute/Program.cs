using BenchmarkDotNet.Running;

namespace BenchmarkDotNet_MemoryDiagnoser_Attribute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SortingBenchmark>();
        }
    }
}