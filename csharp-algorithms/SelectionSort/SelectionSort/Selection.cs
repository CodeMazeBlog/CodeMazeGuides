namespace SelectionSort;

public class Selection
{
    public int[] NumArray { get; set; } = [];

    public int[] SortArray()
    {
        var arrayLength = NumArray.Length;

        for (int i = 0; i < arrayLength - 1; i++)
        {
            var smallestVal = i;

            for (int j = i + 1; j < arrayLength; j++)
            {
                if (NumArray[j] < NumArray[smallestVal])
                {
                    smallestVal = j;
                }
            }

            var tempVar = NumArray[smallestVal];
            NumArray[smallestVal] = NumArray[i];
            NumArray[i] = tempVar;
        }
        return NumArray;
    }

    public static int[] AddRandomElements(int size)
    {
        var array = new int[size];
        var rand = new Random();
        var maxNum = 10000;

        for (int i = 0; i < size; i++)
            array[i] = rand.Next(maxNum + 1);

        return array;
    }

    public static int[] AddSortedElements(int size)
    {
        var array = new int[size];

        for (int i = 0; i < size; i++)
            array[i] = i;

        return array;
    }
}
