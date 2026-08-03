using BenchmarkDotNet.Running;

namespace ReadAndParseAJSONFileInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           BenchmarkRunner.Run<ReadAndParseJSONFileMethodsBenchMark>();
        }
    }
}