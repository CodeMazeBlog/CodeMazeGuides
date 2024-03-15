using BenchmarkDotNet.Running;

namespace HowToSerializeAListToJsonInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SerializeMethodsBenchmark>();
        }
    }
}