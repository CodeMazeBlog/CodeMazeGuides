using BenchmarkDotNet.Attributes;

namespace QuickSort
{
    public class QuickSortMethods
    {
        public IEnumerable<object[]> SampleArrays()
        {
            yield return new object[] { CreateRandomArray(200), 0, 199, "Small Unsorted" };
            yield return new object[] { CreateRandomArray(2000), 0, 1999, "Medium Unsorted" };
            yield return new object[] { CreateRandomArray(10000), 0, 9999, "Large Unsorted" };
            yield return new object[] { CreateSortedArray(200), 0, 199, "Small Sorted" };
            yield return new object[] { CreateSortedArray(2000), 0, 1999, "Medium Sorted" };
            yield return new object[] { CreateSortedArray(10000), 0, 9999, "Large Sorted" };
        }
        public int Partition(int[] array, int leftIndex, int rightIndex)
        {
            var pivot = array[leftIndex];

            while (true)
            {
                while (array[leftIndex] < pivot)
                {
                    leftIndex++;
                }
                while (rightIndex > pivot)
                {
                    rightIndex--;
                }
                if (leftIndex < rightIndex)
                {
                    //if (array[leftIndex] == array[rightIndex])
                    //    return rightIndex;

                    var tempVar = array[rightIndex];
                    array[rightIndex] = array[leftIndex];
                    array[leftIndex] = tempVar;
                }
                else
                {
                    return rightIndex;
                }
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleArrays))]
        public int[] SortArray(int[] array, int leftIndex, int rightIndex, string arrayName)
        {
            if (leftIndex < rightIndex)
            {
                var pivot = Partition(array, leftIndex, rightIndex);

                if (pivot > 1)
                {
                    SortArray(array, leftIndex, pivot - 1, arrayName);
                }
                if (pivot + 1 < rightIndex)
                {
                    SortArray(array, pivot + 1, rightIndex, arrayName);
                }
            }

            return array;
        }
       
        public static int[] CreateRandomArray(int size)
        {
            var array = new int[size];
            var rand = new Random();

            for (int i = 0; i < size; i++)
                array[i] = rand.Next();

            return array;
        }
        public static int[] CreateSortedArray(int size)
        {
            var array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }
    }
}
