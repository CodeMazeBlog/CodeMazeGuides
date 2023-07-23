using BenchmarkDotNet.Attributes;
using SumUpArrayElements;

namespace BenchmarkRunner
{
    public class SumArrayElementsBenchmark
    {
        private readonly SumArrayElements _sumArrayElements = new();
        private static readonly int[] _sourceArray = FillElements(1000 * 100);

        private static int[] FillElements(int length)
        {
            var randomArray = new int[length];

            for (int i = 0; i < length; i++)
                randomArray[i] = new Random().Next(0, 1000);

            return randomArray;
        }

        [Benchmark]
        public void UsingForLoop()
        {
            _sumArrayElements.ForLoop(_sourceArray);
        }

        [Benchmark]
        public void UsingForeachLoop()
        {
            _sumArrayElements.ForeachLoop(_sourceArray);
        }

        [Benchmark]
        public void UsingArrayForEach()
        {
            _sumArrayElements.ArrayForEach(_sourceArray);
        }

        [Benchmark]
        public void UsingEnumerableSum()
        {
            _sumArrayElements.EnumerableSum(_sourceArray);
        }

        [Benchmark]
        public void UsingArraySum()
        {
            _sumArrayElements.ArraySum(_sourceArray);
        }

        [Benchmark]
        public void UsingAggregate()
        {
            _sumArrayElements.Aggregate(_sourceArray);
        }
    }
}