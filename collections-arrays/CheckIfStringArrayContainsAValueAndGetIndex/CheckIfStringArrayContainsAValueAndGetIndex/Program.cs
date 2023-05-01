using BenchmarkDotNet.Running;

namespace CheckIfStringArrayContainsAValueAndGetIndex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<CheckMethodsBenchMark>();
        }
    }
}