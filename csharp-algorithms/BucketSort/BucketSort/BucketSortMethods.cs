using BenchmarkDotNet.Attributes;

namespace BucketSort
{
    public class BucketSortMethods
    {
        public IEnumerable<object[]> SampleArrays()
        {
            yield return new object[] { CreateRandomArray(200), "Small Unsorted" };
            yield return new object[] { CreateRandomArray(2000), "Medium Unsorted" };
            yield return new object[] { CreateRandomArray(20000), "Large Unsorted" };
            yield return new object[] { CreateSortedArray(200), "Small Sorted" };
            yield return new object[] { CreateSortedArray(2000), "Medium Sorted" };
            yield return new object[] { CreateSortedArray(20000), "Large Sorted" };
            yield return new object[] { CreateReversedArray(CreateSortedArray(200)), "Small Reversed" };
            yield return new object[] { CreateReversedArray(CreateSortedArray(2000)), "Medium Reversed" };
            yield return new object[] { CreateReversedArray(CreateSortedArray(20000)), "Large Reversed" };
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleArrays))]
        public int[] SortArray(int[] array, string arrayName)
        {
            if (array == null || array.Length <= 1)
            {
                return array;
            }

            int maxValue = array[0]; 
            int minValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }

                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];

            for (int i = 0; i < array.Length; i++)
            {
                if (bucket[array[i] - minValue] == null)
                {
                    bucket[array[i] - minValue] = new LinkedList<int>();
                }

                bucket[array[i] - minValue].AddLast(array[i]);
            }

            var index = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<int> node = bucket[i].First;

                    while (node != null)
                    {
                        array[index] = node.Value;
                        node = node.Next; 
                        index++;
                    }
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

        public static int[] CreateReversedArray(int[] array)
        {
            Array.Reverse(array);

            return array;
        }
    }
}
