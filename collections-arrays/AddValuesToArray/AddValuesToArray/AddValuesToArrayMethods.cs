namespace AddValuesToArray;
public class AddValuesToArrayMethods
{
    public static int[] ArrayIndexInitializer(int arraySize)
    {
        var array = new int[arraySize];

        for (var index = 0; index < arraySize; index++)
        {
            array[index] = index;
        }

        return array;
    }

    public static int[] SetValueMethod(int arraySize)
    {
        var array = new int[arraySize];

        for (var index = 0; index < arraySize; index++)
        {
            array.SetValue(value: index, index: index);
        }

        return array;
    }
    public static int[] UsingList(int arraySize)
    {
        var list = new List<int>();

        for (var index = 0; index < arraySize; index++)
        {
            list.Add(index);
        }

        return list.ToArray();
    }

    public static int[] LinqConcat(int arraySize)
    {
        var array1 = Array.Empty<int>();
        var array2 = Enumerable.Range(0, arraySize).Select(x => x).ToArray();

        array1 = array1.Concat(array2).ToArray();

        return array1;
    }

    public static int[] LinqAppend(int arraySize)
    {
        var array = Array.Empty<int>();
        for (var index = 0; index < arraySize; index++)
        {
            array = array.Append(index).ToArray();
        }

        return array;
    }

    public static int[] ArrayResize(int arraySize)
    {
        var array = Array.Empty<int>();
        Array.Resize(ref array, arraySize);

        for (var index = 0; index < arraySize; index++)
        {
            array[index] = index;
        }

        return array;
    }

    public static int[] ArrayCopyTo(int arraySize)
    {
        var array1 = new int[arraySize];
        var array2 = Enumerable.Range(0, arraySize).Select(x => x).ToArray();

        array2.CopyTo(array1, 0);

        return array1;
    }
}
