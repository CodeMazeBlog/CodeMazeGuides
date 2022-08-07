namespace AddValuesToArray;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(nameof(AddValuesToArrayMethods.ArrayIndexInitilizer));
        var array1 = AddValuesToArrayMethods.ArrayIndexInitilizer(5);
        Console.WriteLine(string.Join(", ", array1));

        Console.WriteLine(nameof(AddValuesToArrayMethods.SetValueMethod));
        var array2 = AddValuesToArrayMethods.SetValueMethod(5);
        Console.WriteLine(string.Join(", ", array2));

        Console.WriteLine(nameof(AddValuesToArrayMethods.LinqList));
        var array3 = AddValuesToArrayMethods.LinqList(5);
        Console.WriteLine(string.Join(", ", array3));

        Console.WriteLine(nameof(AddValuesToArrayMethods.LinqConcat));
        var array4 = AddValuesToArrayMethods.LinqConcat(5);
        Console.WriteLine(string.Join(", ", array4));

        Console.WriteLine(nameof(AddValuesToArrayMethods.LinqAppend));
        var array5 = AddValuesToArrayMethods.LinqAppend(5);
        Console.WriteLine(string.Join(", ", array5));

        Console.WriteLine(nameof(AddValuesToArrayMethods.ArrayResize));
        var array6 = AddValuesToArrayMethods.ArrayResize(5);
        Console.WriteLine(string.Join(", ", array6));
    }
}
