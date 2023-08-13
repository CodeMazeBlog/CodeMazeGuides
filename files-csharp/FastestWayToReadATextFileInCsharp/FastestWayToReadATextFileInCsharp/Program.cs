using BenchmarkDotNet.Running;

namespace FastestWayToReadATextFileInCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<WaysToReadATextFileInCsharpBenchmark>();
        }
    }
}