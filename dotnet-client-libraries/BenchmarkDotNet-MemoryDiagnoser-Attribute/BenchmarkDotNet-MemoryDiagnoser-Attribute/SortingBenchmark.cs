using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNet_MemoryDiagnoser_Attribute
{
    [MemoryDiagnoser(true)]
    public class SortingBenchmark
    {
        private const int ARRAY_SIZE = 1000000;
        private int[] quickSortArray;
        private int[] mergeSortArray;
        private int[] bogoSortArray;

        [GlobalSetup]
        public void Setup()
        {
            // Create two arrays of random integers to sort
            Random random = new Random();
            quickSortArray = new int[ARRAY_SIZE];
            mergeSortArray = new int[ARRAY_SIZE];

            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                int randomNumber = random.Next();
                quickSortArray[i] = randomNumber;
                mergeSortArray[i] = randomNumber;
                bogoSortArray[i] = randomNumber;
            }
        }

        [Benchmark]
        public void QuickSort()
        {
            Setup();
            // Call the QuickSort algorithm to sort the array
            Sort.QuickSort(quickSortArray, 0, quickSortArray.Length - 1);
        }

        [Benchmark]
        public void MergeSort()
        {
            Setup();
            // Call the MergeSort algorithm to sort the array
            Sort.MergeSort(mergeSortArray, 0, mergeSortArray.Length - 1);
        }

        [Benchmark]
        public void BogoSort()
        {
            Setup();
            // Call the BogokSort algorithm to sort the array
            Sort.BogoSort(bogoSortArray);
        }
    }
}
