using BenchmarkDotNet.Running;

namespace CountingCharOccurences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<CountChars>();
        }
    }
}