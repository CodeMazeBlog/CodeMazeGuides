using BenchmarkDotNet.Attributes;

namespace HowToEfficientlyRandomizeAnArray
{
    [RankColumn]
    [MemoryDiagnoser(false)]
    public class ArrayBenchmarks
    {
        private int[] _guidArray;
        private int[] _randomArray;
        private int[] _fisherYatesArray;
        private int[] _fisherYatesArrayCopy;
        private const int ARRAY_SIZE = 100000;

        [GlobalSetup]
        public void Setup()
        {
            _guidArray = ArrayFunctions.GetOrderedArray(ARRAY_SIZE);
            _randomArray = ArrayFunctions.GetOrderedArray(ARRAY_SIZE);
            _fisherYatesArray = ArrayFunctions.GetOrderedArray(ARRAY_SIZE);
            _fisherYatesArrayCopy = ArrayFunctions.GetOrderedArray(ARRAY_SIZE);
        }

        [Benchmark]
        public void RandomizeWithOrderByAndGuid()
        {
            ArrayFunctions.RandomizeWithOrderByAndGuid(_guidArray);
        }

        [Benchmark]
        public void RandomizeWithOrderByAndRandom()
        {
            ArrayFunctions.RandomizeWithOrderByAndRandom(_randomArray);
        }

        [Benchmark]
        public void RandomizeWithFisherYates()
        {
            ArrayFunctions.RandomizeWithFisherYates(_fisherYatesArray);
        }

        [Benchmark]
        public void RandomizeWithFisherYatesCopiedArray()
        {
            ArrayFunctions.RandomizeWithFisherYatesCopiedArray(_fisherYatesArrayCopy);
        }
    }
}
