using BenchmarkDotNet.Running;

namespace SwashbuckleVsNSwag.Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SwashbuckleVsNSwagBenchmark>();
            Console.ReadKey();
        }
    }
}
