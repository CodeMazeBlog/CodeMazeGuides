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

    public static int[] UsingList(int arraySize, List<int> list)
    {
        return list.ToArray();
    }

    public static int[] LinqConcat(int[] array)
    {
        var array1 = Array.Empty<int>();

        array1 = array1.Concat(array).ToArray();

        return array1;
    }

    public static int[] ArrayCopyTo(int arraySize, int[] array)
    {
        var array1 = new int[arraySize];       

        array.CopyTo(array1, 0);

        return array1;
    }
}
