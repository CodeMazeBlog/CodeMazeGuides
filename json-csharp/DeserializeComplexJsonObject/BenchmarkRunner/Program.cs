namespace BenchmarkRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<DeserializerBenchmark>();
        }
    }
}
