using BenchmarkDotNet.Attributes;

namespace RadixSort
{
    public class RadixSortMethods
    {
        public IEnumerable<object[]> SampleArrays()
        {
            yield return new object[] { CreateRandomArray(20000, 10000, 30000), 20000, "Best Case" };
            yield return new object[] { CreateSortedArray(20000), 20000, "Average Case" };
            yield return new object[] { CreateImbalancedArray(CreateRandomArray(19999, 10000, 30000)), 20000, "Worst Case" };
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleArrays))]
        public int[] RadixSort (int[] array, int size, string arrayName)
        {
            var maxVal = GetMaxVal(array, size);

            for (int exponent = 1; maxVal / exponent > 0; exponent *= 10)
                CountingSort(array, size, exponent);

            return array;
        }

        public static int GetMaxVal(int[] array, int size)
        {
            var maxVal = array[0];

            for (int i = 1; i < size; i++)
                if (array[i] > maxVal)
                    maxVal = array[i];

            return maxVal;
        }

        public static void CountingSort(int[] array, int size, int exponent)
        {
            var outputArr = new int[size];
            var occurences = new int[10];

            for (int i = 0; i < 10; i++)
                occurences[i] = 0;

            for (int i = 0; i < size; i++)
                occurences[(array[i] / exponent) % 10]++;

            for (int i = 1; i < 10; i++)
                occurences[i] += occurences[i - 1];

            for (int i = size - 1; i >= 0; i--)
            {
                outputArr[occurences[(array[i] / exponent) % 10] - 1] = array[i];
                occurences[(array[i] / exponent) % 10]--;
            }

            for (int i = 0; i < size; i++)
                array[i] = outputArr[i];
        }

        public static int[] CreateRandomArray(int size, int lower, int upper)
        {
            var array = new int[size];
            var rand = new Random();

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(lower, upper);

            return array;
        }

        public static int[] CreateSortedArray(int size)
        {
            var array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }

        public static int[] CreateImbalancedArray(int[] array)
        {
            List<int> numbers = new List<int>();

            numbers.AddRange(array);
            numbers.Add(Int32.MaxValue);

            return numbers.ToArray();
        }

    }
}
