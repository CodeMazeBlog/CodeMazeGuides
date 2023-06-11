using BenchmarkDotNet.Running;

namespace HowToConvertAStreamToAByteArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ConvertMethodsBenchmark>();
        }
    }
}