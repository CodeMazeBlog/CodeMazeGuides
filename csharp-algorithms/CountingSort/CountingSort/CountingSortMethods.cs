using BenchmarkDotNet.Attributes;

namespace CountingSort
{
    public class CountingSortMethods
    {
        public IEnumerable<object[]> SampleArrays()
        {
            yield return new object[] { CreateRandomArray(20000, 1, 2), "Best Case" };
            yield return new object[] { CreateRandomArray(20000, 10000, 30000), "Average Case" };
            yield return new object[] { CreateImbalancedArray(CreateRandomArray(19999, 10000, 30000)), "Worst Case" };
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleArrays))]
        public int[] CountingSort(int[] array, string arrayName)
        {
            var size = array.Length;
            var maxElement = GetMaxVal(array, size);
            var occurrences = new int[maxElement + 1];

            for (int i = 0; i < maxElement + 1; i++)
            {
                occurrences[i] = 0;
            }

            for (int i = 0; i < size; i++)
            {
                occurrences[array[i]]++;
            }

            for (int i = 0, j = 0; i <= maxElement; i++)
            {
                while (occurrences[i] > 0)
                {
                    array[j] = i;
                    j++;
                    occurrences[i]--;
                }
            }

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

        
        public static int[] CreateRandomArray(int size, int lower, int upper)
        {
            var array = new int[size];
            var rand = new Random();

            for (int i = 0; i < size; i++)
                array[i] = rand.Next(lower, upper);

            return array;
        }

        public static int[] CreateImbalancedArray(int[] array)
        {
            List<int> numbers = new List<int>();

            numbers.AddRange(array);
            numbers.Add(Int32.MaxValue/2);

            return numbers.ToArray();
        }

    }
}
