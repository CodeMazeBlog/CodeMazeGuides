namespace AddValuesToArray;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(nameof(AddValuesToArrayMethods.ArrayIndexInitializer));
        var array1 = AddValuesToArrayMethods.ArrayIndexInitializer(5);
        Console.WriteLine(string.Join(", ", array1));

        Console.WriteLine(nameof(AddValuesToArrayMethods.SetValueMethod));
        var array2 = AddValuesToArrayMethods.SetValueMethod(5);
        Console.WriteLine(string.Join(", ", array2));

        Console.WriteLine(nameof(AddValuesToArrayMethods.UsingList));
        var list = Enumerable.Range(0, 5).ToList();
        var array3 = AddValuesToArrayMethods.UsingList(5, list);
        Console.WriteLine(string.Join(", ", array3));

        Console.WriteLine(nameof(AddValuesToArrayMethods.LinqConcat));
        var populatedArray = Enumerable.Range(0, 5).ToArray();
        var array4 = AddValuesToArrayMethods.LinqConcat(populatedArray);
        Console.WriteLine(string.Join(", ", array4));

        Console.WriteLine(nameof(AddValuesToArrayMethods.ArrayCopyTo));
        var populatedArray1 = Enumerable.Range(0, 5).ToArray();
        var array7 = AddValuesToArrayMethods.ArrayCopyTo(5, populatedArray1);
        Console.WriteLine(string.Join(", ", array7));
    }
}
