using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNet_MemoryDiagnoser_Attribute
{
    [MemoryDiagnoser(true)]
    public class SortingBenchmark
    {
        private const int ARRAY_SIZE = 10_000;
        private int[] _quickSortArray;
        private int[] _mergeSortArray;

        [GlobalSetup]
        public void Setup()
        {
            Random random = new Random();
            _quickSortArray = new int[ARRAY_SIZE];
            _mergeSortArray = new int[ARRAY_SIZE];

            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                int randomNumber = random.Next();
                _quickSortArray[i] = randomNumber;
                _mergeSortArray[i] = randomNumber;
            }
        }

        [Benchmark]
        public void QuickSort()
        {
            Sort.QuickSort(_quickSortArray, 0, _quickSortArray.Length - 1);
        }

        [Benchmark]
        public void MergeSort()
        {
            Sort.MergeSort(_mergeSortArray, 0, _mergeSortArray.Length - 1);
        }
    }
}
