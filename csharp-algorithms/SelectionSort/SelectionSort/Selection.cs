using BenchmarkDotNet.Attributes;

namespace SelectionSort
{
    public class Selection
    {
        [ParamsSource(nameof(ArraySizes))]
        public int[]? NumArray { get; set; }
        int[] smallArray = AddRandomElements(200);
        int[] mediumArray = AddRandomElements(2000);
        int[] largeArray = AddRandomElements(200000);
        int[] sortedSmallArray = AddSortedElements(200);
        int[] sortedMediumArray = AddSortedElements(2000);
        int[] sortedLargeArray = AddSortedElements(200000);
        public IEnumerable<int[]> ArraySizes => new[] { sortedSmallArray, sortedMediumArray, sortedLargeArray };
        
        [Benchmark]
        public int[] SortArray()
        {
            var arrayLength = NumArray.Length;

            for (int i = 0; i < arrayLength - 1; i++)
            {
                var smallestVal = i;

                for (int j = i + 1; j < arrayLength; j++)
                {
                    if (NumArray[j] < NumArray[smallestVal])
                    {
                        smallestVal = j;
                    }
                }

                var tempVar = NumArray[smallestVal];
                NumArray[smallestVal] = NumArray[i];
                NumArray[i] = tempVar;
            }
            return NumArray;
        }

        public static int[] AddRandomElements(int size)
        {
            var array = new int[size];
            var rand = new Random();
            var maxNum = 10000;

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(maxNum + 1);

            return array;
        }

        public static int[] AddSortedElements(int size)
        {
            var array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }
    }
}
