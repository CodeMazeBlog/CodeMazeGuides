using BenchmarkDotNet.Attributes;

namespace BubbleSort
{
    public class Bubble
    {
        [ParamsSource(nameof(ArraySizes))]
        public int[]? NumArray { get; set; }
        int[] smallArray = GenerateRandomNumber(200);
        int[] mediumArray = GenerateRandomNumber(2000);
        int[] largeArray = GenerateRandomNumber(200000);
        int[] sortedSmallArray = GenerateSortedNumber(200);
        int[] sortedMediumArray = GenerateSortedNumber(2000);
        int[] sortedLargeArray = GenerateSortedNumber(200000);
        public IEnumerable<int[]> ArraySizes => new[] { sortedSmallArray, sortedMediumArray, sortedLargeArray };

        [Benchmark]
        public int[] SortArray() 
        {
            var n = NumArray.Length;

            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (NumArray[j] > NumArray[j + 1])
                    {
                        var tempVar = NumArray[j];
                        NumArray[j] = NumArray[j + 1];
                        NumArray[j + 1] = tempVar;
                    }

            return NumArray;
        }

        [Benchmark]
        public int[] SortOptimizedArray()
        {
            var n = NumArray.Length;
            bool swapRequired;

            for (int i = 0; i < n - 1; i++) 
            {
                swapRequired = false;
                for (int j = 0; j < n - i - 1; j++)
                    if (NumArray[j] > NumArray[j + 1])
                    {
                        var tempVar = NumArray[j];
                        NumArray[j] = NumArray[j + 1];
                        NumArray[j + 1] = tempVar;
                        swapRequired = true;
                    }
                if (swapRequired == false)
                    break;
            }
   
            return NumArray;
        }

        public static int[] GenerateRandomNumber(int size)
        {
            var array = new int[size];
            var rand = new Random();
            var maxNum = 10000;

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(maxNum + 1);

            return array;
        }

        public static int[] GenerateSortedNumber(int size)
        {
            var array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }
    }
}
