using System.Diagnostics;

namespace StopWatchCSharp
{
    public class StopWatchMethods
    {
        public Stopwatch BubbleSort(int[] numArray, int size)
        {
            var stopWatch = new Stopwatch();
            
            stopWatch.Start();

            for (int i = 0; i < size - 1; i++)
                for (int j = 0; j < size - i - 1; j++)
                    if (numArray[j] > numArray[j + 1])
                    {
                        var tempVar = numArray[j];
                        numArray[j] = numArray[j + 1];
                        numArray[j + 1] = tempVar;
                    }

            stopWatch.Stop();

            return stopWatch;
        }

        public Stopwatch HeapSort(int[] array, int size)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();

            if (size <= 1) 
            {
                stopWatch.Stop();

                return stopWatch;
            }
                
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

            stopWatch.Stop();

            return stopWatch;
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

        public int[] CreateRandomArray(int size)
        {
            var array = new int[size];
            var rand = new Random();

            for (int i = 0; i < size; i++)
                array[i] = rand.Next();

            return array;
        }
    }
}