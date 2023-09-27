namespace BenchmarkRunner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<ArrayPopulatorBenchmark>();
        }
    }
}