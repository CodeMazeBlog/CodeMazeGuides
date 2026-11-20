namespace InsertionSort;

public class InsertionSortMethods
{
    public int[] SortArray(int[] array, int length)
    {
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

    public int[] SortArrayRecursive(int[] array, int length) 
    {
        if (length <= 1)
        {
            return array;
        }

        SortArrayRecursive(array, length - 1);
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
