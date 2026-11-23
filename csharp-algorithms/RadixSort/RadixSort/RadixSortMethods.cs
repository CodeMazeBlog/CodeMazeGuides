namespace RadixSort;

public class RadixSortMethods
{
    public int[] RadixSort(int[] array, int size)
    {
        if (size == 0)
            return array;

        var maxVal = GetMaxVal(array, size);

        for (long exponent = 1; maxVal / exponent > 0; exponent *= 10)
            CountingSort(array, size, exponent);

        return array;
    }

    public int[] RadixSortWithNegatives(int[] array, int size)
    {
        if (size == 0)
            return array;

        var minVal = GetMinVal(array, size);

        if (minVal >= 0)
            return RadixSort(array, size);

        for (int i = 0; i < size; i++)
            array[i] = checked(array[i] - minVal);

        RadixSort(array, size);

        for (int i = 0; i < size; i++)
            array[i] += minVal;

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

    public static int GetMinVal(int[] array, int size)
    {
        var minVal = array[0];

        for (int i = 1; i < size; i++)
            if (array[i] < minVal)
                minVal = array[i];

        return minVal;
    }

    public static void CountingSort(int[] array, int size, long exponent)
    {
        var outputArr = new int[size];
        var occurrences = new int[10];

        for (int i = 0; i < size; i++)
            occurrences[(array[i] / exponent) % 10]++;

        for (int i = 1; i < 10; i++)
            occurrences[i] += occurrences[i - 1];

        for (int i = size - 1; i >= 0; i--)
        {
            outputArr[occurrences[(array[i] / exponent) % 10] - 1] = array[i];
            occurrences[(array[i] / exponent) % 10]--;
        }

        for (int i = 0; i < size; i++)
            array[i] = outputArr[i];
    }

    public static int[] CreateRandomArray(int size, int lower, int upper)
    {
        var array = new int[size];

        for (int i = 0; i < size; i++)
            array[i] = Random.Shared.Next(lower, upper);

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
        List<int> numbers = [.. array, int.MaxValue];

        return numbers.ToArray();
    }
}
