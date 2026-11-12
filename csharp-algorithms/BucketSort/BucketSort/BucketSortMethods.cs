namespace BucketSort;

public class BucketSortMethods
{
    public int[] SortArray(int[] array)
    {
        if (array.Length <= 1)
        {
            return array;
        }

        List<int> sortedList = [];
        var minValue = array[0];
        var maxValue = array[0];

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxValue)
                maxValue = array[i];
            if (array[i] < minValue)
                minValue = array[i];
        }

        var numberOfBuckets = array.Length;
        var range = (long)maxValue - minValue + 1;
        List<int>[] bucket = new List<int>[numberOfBuckets];

        for (int i = 0; i < numberOfBuckets; i++)
        {
            bucket[i] = [];
        }

        for (int i = 0; i < array.Length; i++)
        {
            var selectedBucket = (int)((array[i] - (long)minValue) * numberOfBuckets / range);
            bucket[selectedBucket].Add(array[i]);
        }

        for (int i = 0; i < numberOfBuckets; i++)
        {
            int[] temp = BubbleSort(bucket[i]);
            sortedList.AddRange(temp);
        }

        return sortedList.ToArray();
    }

    public static int[] BubbleSort(List<int> listInput)
    {
        for (int i = 0; i < listInput.Count - 1; i++)
        {
            for (int j = 0; j < listInput.Count - i - 1; j++)
            {
                if (listInput[j] > listInput[j + 1])
                {
                    var temp = listInput[j];
                    listInput[j] = listInput[j + 1];
                    listInput[j + 1] = temp;
                }
            }
        }

        return listInput.ToArray();
    }

    public int[] SortArrayOptimized(int[] array)
    {
        if (array.Length <= 1)
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

        var range = (long)maxValue - minValue + 1;
        LinkedList<int>[] bucket = new LinkedList<int>[range];

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
                LinkedListNode<int>? node = bucket[i].First;

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
            array[i] = rand.Next(1, size);

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
