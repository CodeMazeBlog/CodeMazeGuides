using BenchmarkDotNet.Attributes;
using FindTheMaximumValue;

namespace BenchmarkRunner
{
    public class ElementFinderBenchmark
    {
        private static readonly int[] _sourceArray = FillElements(1000 * 100);
        private readonly ElementFinder _elementFinder = new();

        private static int[] FillElements(int length)
        {
            var sourceArray = new int[length];
            for (int i = 0; i < length; i++)
                sourceArray[i] = new Random().Next(0, 1000);

            return sourceArray;
        }

        [Benchmark]
        public void GetLargestElementUsingMax()
        {
            _elementFinder.GetLargestElementUsingMax(_sourceArray);
        }

        [Benchmark]
        public void GetLargestElementUsingOrderByDescending()
        {
            _elementFinder.GetLargestElementUsingOrderByDescending(_sourceArray);
        }

        [Benchmark]
        public void GetLargestElementUsingMaxBy()
        {
            _elementFinder.GetLargestElementUsingMaxBy(_sourceArray);
        }

        [Benchmark]
        public void GetLargestElementUsingFor()
        {
            _elementFinder.GetLargestElementUsingFor(_sourceArray);
        }
    }
}
