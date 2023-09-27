using BenchmarkDotNet.Attributes;

namespace HeapSort
{
    public class HeapSortMethods
    {
        public IEnumerable<object[]> SampleArrays()
        {
            yield return new object[] { CreateSortedArray(2000000), 2000000, "Worst Case" };
            yield return new object[] { CreateRandomArray(2000000, 1, 2000000), 2000000, "Average Case" };
            yield return new object[] { CreateIdenticalArray(2000000, 1, 2000000), 2000000, "Best Case" };
        }

        [Benchmark]
        [ArgumentsSource(nameof(SampleArrays))]
        public int[] SortArray(int[] array, int size, string arrayName)
        {
            if (size <= 1)
                return array;

            for (int i = size / 2 - 1; i >= 0; i--)
            {
                Heapify(array, size, i);
            }

            for (int i = size - 1; i >= 0; i--)
            {
                var tempVar = array[0];
                array[0] = array[i];
                array[i] = tempVar;

                Heapify(array, i, 0);
            }

            return array;
        }

        static void Heapify(int[] array, int size, int index)
        {
            var largestIndex = index;
            var leftChild = 2 * index + 1;
            var rightChild = 2 * index + 2;

            if (leftChild < size && array[leftChild] > array[largestIndex])
            {
                largestIndex = leftChild;
            }

            if (rightChild < size && array[rightChild] > array[largestIndex])
            {
                largestIndex = rightChild;
            }

            if (largestIndex != index)
            {
                var tempVar = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = tempVar;

                Heapify(array, size, largestIndex);
            }
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

        public static int[] CreateIdenticalArray(int size, int lower, int upper)
        {
            var array = new int[size];
            var rand = new Random();

            var selectedElement = rand.Next(lower, upper);

            for (int i = 0; i < size; i++)
            {
                array[i] = selectedElement;
            }

            return array;
        }
    }
}
