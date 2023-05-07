using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNet_MemoryDiagnoser_Attribute
{
    [MemoryDiagnoser(true)]
    public class SortingBenchmark
    {
        private const int ARRAY_SIZE = 100_000;
        private int[] quickSortArray;
        private int[] mergeSortArray;

        [GlobalSetup]
        public void Setup()
        {
            Random random = new Random();
            quickSortArray = new int[ARRAY_SIZE];
            mergeSortArray = new int[ARRAY_SIZE];

            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                int randomNumber = random.Next();
                quickSortArray[i] = randomNumber;
                mergeSortArray[i] = randomNumber;
            }
        }

        [Benchmark]
        public void QuickSort()
        {
            Sort.QuickSort(quickSortArray, 0, quickSortArray.Length - 1);
        }

        [Benchmark]
        public void MergeSort()
        {
            Sort.MergeSort(mergeSortArray, 0, mergeSortArray.Length - 1);
        }
    }
}
