namespace CountingSort;

public class CountingSortMethods
{
    public int[] CountingSort(int[] array)
    {
        var size = array.Length;
        if (size == 0)
            return array;

        var maxElement = GetMaxVal(array, size);
        var occurrences = new int[maxElement + 1];

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

    public static T[] StableCountingSort<T>(T[] items, Func<T, int> getKey)
    {
        if (items.Length == 0)
            return [];

        var min = items.Min(getKey);
        var max = items.Max(getKey);
        var range = (long)max - min + 1;
        if (range > Array.MaxLength)
            throw new ArgumentOutOfRangeException(nameof(items), "The key range is too wide for counting sort.");

        var counts = new int[range];

        foreach (var item in items)
            counts[getKey(item) - min]++;

        for (int i = 1; i < counts.Length; i++)
            counts[i] += counts[i - 1];

        var sorted = new T[items.Length];

        for (int i = items.Length - 1; i >= 0; i--)
        {
            var index = getKey(items[i]) - min;
            counts[index]--;
            sorted[counts[index]] = items[i];
        }

        return sorted;
    }

    public static int[] CreateRandomArray(int size, int lower, int upper)
    {
        var array = new int[size];
        var rand = new Random();

        for (int i = 0; i < size; i++)
            array[i] = rand.Next(lower, upper);

        return array;
    }

    public static int[] CreateImbalancedArray(int[] array) => [.. array, 2_000_000];
}
