using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using RemoveFromListWhileIterating;

namespace RemoveFromListWhileIteratingBenchmark
{
    [MemoryDiagnoser]
    public class RemoveFromListWhileIteratingBenchmark
    {
        private readonly int _testIterations = 100;
        private readonly List<int> _numberList = Enumerable.Range(1, 200000).ToList();

        [Benchmark]
        public void RunReverseIterate()
        {
            for (int i = 0; i < _testIterations; i++)
            {
                RemoveFromListWhileIteratingProgram.ReverseIterate(_numberList);
            }
        }

        [Benchmark]
        public void RunSimpleIterateRemoveWithToList()
        {
            for (int i = 0; i < _testIterations; i++)
            {
                RemoveFromListWhileIteratingProgram.SimpleIterateRemoveWithToList(_numberList);
            }
        }

        [Benchmark]
        public void RunOneLineRemoveAll()
        {
            for (int i = 0; i < _testIterations; i++)
            {
                RemoveFromListWhileIteratingProgram.OneLineRemoveAll(_numberList);
            }
        }

        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<RemoveFromListWhileIteratingBenchmark>();
        }
    }
}
