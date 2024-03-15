using BenchmarkDotNet.Running;

namespace GenerateStreamFromStringInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<GenerateStreamFromStringBenchmark>();
        }
    }
}