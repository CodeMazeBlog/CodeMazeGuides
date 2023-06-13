using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;

namespace HowToEfficientlyRandomizeAnArray
{
    [MemoryDiagnoser(true)]
    public class ArrayBenchmarks
    {
        private int[] _guidArray;
        private int[] _randomArray;
        private int[] _fisherYatesArray;
        private const int ARRAY_SIZE = 100000;
        private ArrayFunctions _arrayFunctions;


        [GlobalSetup]
        public void Setup()
        {
            _arrayFunctions = new ArrayFunctions();
            _guidArray = _arrayFunctions.GerOrderedArray(ARRAY_SIZE);
            _randomArray = _arrayFunctions.GerOrderedArray(ARRAY_SIZE);
            _fisherYatesArray = _arrayFunctions.GerOrderedArray(ARRAY_SIZE);
        }

        [Benchmark]
        public void RandomizeWithOrderByAndGuid()
        {
            _arrayFunctions.RandomizeWithOrderByAndGuid(_guidArray);
        }

        [Benchmark]
        public void RandomizeWithOrderByAndRandom()
        {
            _arrayFunctions.RandomizeWithOrderByAndRandom(_randomArray);
        }

        [Benchmark]
        public void RandomizeWithFisherYates()
        {
            _arrayFunctions.RandomizeWithFisherYates(_fisherYatesArray);
        }
    }
}
