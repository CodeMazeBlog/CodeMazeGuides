using BenchmarkDotNet.Attributes;

namespace ShellSort
{
    public class ShellSortMethods
    {
        public IEnumerable<object[]> SampleArrays()
        {
            yield return new object[] { CreateSortedArray(2000000), 2000000, "Best Case" };
            yield return new object[] { CreateRandomArray(2000000, 1, 2000000), 2000000, "Average Case" };
            yield return new object[] { CreateImbalancedArray(2000000, 1, 2000000), 2000000, "Worst Case" };
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleArrays))]
        public int[] ShellSort(int[] array, int size, string arrayName)
        {
            for (int interval = size / 2; interval > 0; interval /= 2)
            {
                for (int i = interval; i < size; i++)
                {
                    var currentKey = array[i];
                    var k = i;

                    while (k >= interval && array[k - interval] > currentKey)
                    {
                        array[k] = array[k - interval];
                        k -= interval;
                    }

                    array[k] = currentKey;
                }
            }

            return array;
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

        public static int[] CreateImbalancedArray(int size, int lower, int upper)
        {
            var array = new int[size];
            var rand = new Random();

            for (int i = 0; i < size; i++) 
            {
                if ((i % 2) == 0)
                {
                    array[i] = rand.Next(upper/2, upper);
                }
                else 
                {
                    array[i] = rand.Next(lower, 1000);
                }    
            }

            return array;
        }
    }
}
