namespace ProgramBenchmarkRunner
{
    public class ProgramBenchmark
    {
        static void Main(string[] args)
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<BenchmarkRunner.DictionaryIterateBenchmark>();
        }
    }
}
