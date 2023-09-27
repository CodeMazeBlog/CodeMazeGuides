using BenchmarkDotNet.Attributes;

namespace InsertionSort
{
    public class InsertionSortMethods
    {
        public IEnumerable<object[]> SampleArrays()
        {
            yield return new object[] { CreateRandomArray(200), 200, "Small Unsorted" };
            yield return new object[] { CreateRandomArray(2000), 2000, "Medium Unsorted" };
            yield return new object[] { CreateRandomArray(20000), 20000, "Large Unsorted" };
            yield return new object[] { CreateSortedArray(200), 200, "Small Sorted" };
            yield return new object[] { CreateSortedArray(2000), 2000, "Medium Sorted" };
            yield return new object[] { CreateSortedArray(20000), 20000, "Large Sorted" };
            yield return new object[] { CreateReversedArray(CreateSortedArray(200)), 200, "Small Reversed" };
            yield return new object[] { CreateReversedArray(CreateSortedArray(2000)), 2000, "Medium Reversed" };
            yield return new object[] { CreateReversedArray(CreateSortedArray(20000)), 20000, "Large Reversed" };
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleArrays))]
        public int[] SortArray(int[] array, int length, string arrayName)
        {
            if (length <= 1)
            {
                return array;
            }

            for (int i = 1; i < length; i++)
            {
                var key = array[i];
                var flag = 0;

                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (key < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = key;
                    }
                    else flag = 1;
                }
            }

            return array;
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleArrays))]
        public int[] SortArrayRecursive(int[] array, int length, string arrayName) 
        {
            if (length <= 1)
            {
                return array;
            }

            SortArrayRecursive(array, length - 1, arrayName);
            var key = array[length - 1];
            var k = length - 2;

            while (k >= 0 && array[k] > key)
            {
                array[k + 1] = array[k];
                k = k - 1;
            }

            array[k + 1] = key;

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

        public static int[] CreateReversedArray(int[] array)
        {
            Array.Reverse(array);

            return array;
        }
    }
}
