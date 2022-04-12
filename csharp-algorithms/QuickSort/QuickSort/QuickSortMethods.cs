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
       
        [Benchmark]
        [ArgumentsSource(nameof(SampleArrays))]
        public int[] SortArray(int[] array, int leftIndex, int rightIndex, string arrayName)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
                
                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            
            if (leftIndex < j)
                SortArray(array, leftIndex, j, arrayName);

            if (i < rightIndex)
                SortArray(array, i, rightIndex, arrayName);

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
