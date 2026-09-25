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

    public static int[] UsingList(List<int> list)
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

    public static int[] AppendWithResize(int[] array, int value)
    {
        Array.Resize(ref array, array.Length + 1);
        array[^1] = value;

        return array;
    }

    public static int[] AppendWithCollectionExpression(int[] array, int value) => [.. array, value];

    public static int[] CollectionExpression(int[] array) => [.. array];

    public static int[] GrowWithResize(int count)
    {
        var array = Array.Empty<int>();

        for (var index = 0; index < count; index++)
        {
            Array.Resize(ref array, array.Length + 1);
            array[index] = index;
        }

        return array;
    }

    public static int[] GrowWithList(int count)
    {
        var list = new List<int>();

        for (var index = 0; index < count; index++)
        {
            list.Add(index);
        }

        return list.ToArray();
    }
}
