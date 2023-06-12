using BenchmarkRunner;

namespace BenchmarkRunner
{
    public class Program
    {
        static void Main()
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<RemoveDuplicateElementsBenchmark>();
        }
    }
}