namespace QuickSort;

public class QuickSortMethods
{
    public int[] SortArray(int[] array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];

        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }

            while (array[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            SortArray(array, leftIndex, j);

        if (i < rightIndex)
            SortArray(array, i, rightIndex);

        return array;
    }

    public int[] SortArrayWithMiddlePivot(int[] array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex + (rightIndex - leftIndex) / 2];

        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }

            while (array[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            SortArrayWithMiddlePivot(array, leftIndex, j);

        if (i < rightIndex)
            SortArrayWithMiddlePivot(array, i, rightIndex);

        return array;
    }

    public static int[] CreateRandomArray(int size)
    {
        var array = new int[size];

        for (int i = 0; i < size; i++)
            array[i] = Random.Shared.Next();

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
