using BenchmarkDotNet.Running;

namespace UsingTrieForPatternSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<PatternSearchBenchmark>();
            Console.WriteLine(summary);
        }
    }
}