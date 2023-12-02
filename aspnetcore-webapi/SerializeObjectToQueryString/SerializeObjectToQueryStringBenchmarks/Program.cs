using BenchmarkDotNet.Running;

namespace SerializeObjectToQueryStringBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SerializeObjectToQueryStringBenchmarks>();

            Console.WriteLine(summary);
        }
    }
}