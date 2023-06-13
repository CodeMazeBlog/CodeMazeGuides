using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Mathematics;

namespace HowToEfficientlyRandomizeAnArray
{
    [MemoryDiagnoser(true)]
    [RankColumn(NumeralSystem.Arabic)]
    public class ArrayBenchmarks
    {
        private const int ARRAY_SIZE = 100000;
        private int[] _guidArray;
        private int[] _randomArray;
        private int[] _fisherYatesArray;


        [GlobalSetup]
        public void Setup()
        {
            _guidArray = ArrayFunctions.GerOrderedArray(ARRAY_SIZE);
            _randomArray = ArrayFunctions.GerOrderedArray(ARRAY_SIZE);
            _fisherYatesArray = ArrayFunctions.GerOrderedArray(ARRAY_SIZE);
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
    }
}
