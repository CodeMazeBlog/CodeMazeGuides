using ConvertString2Int;

namespace BenchmarkRunner
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<ConvertString2IntBenchmark>();

            Console.ReadKey();
        }
    }
}