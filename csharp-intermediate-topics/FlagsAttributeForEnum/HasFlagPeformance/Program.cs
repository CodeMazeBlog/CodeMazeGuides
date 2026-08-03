using BenchmarkDotNet.Running;

namespace HasFlagPeformance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<HasFlagBenchmarker>();
        }
    }
}
