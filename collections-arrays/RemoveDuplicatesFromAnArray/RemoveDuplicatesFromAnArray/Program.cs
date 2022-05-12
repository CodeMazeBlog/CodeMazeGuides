namespace RemoveDuplicatesFromAnArray;

class Program
{
    private static readonly RemoveDuplicateElements _duplicatesRemoval = new RemoveDuplicateElements();
    static void Main(string[] args)
    {
        string[] arrayWithDuplicateValues = new string[] { "value1", "value1", "value2", "value2"};
        Console.WriteLine("Input = {0}", string.Join(",", arrayWithDuplicateValues));

        Console.WriteLine();
        Console.WriteLine("Remove duplicates with distinct linq method");
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.WithDistinctLINQMethod(arrayWithDuplicateValues)));
        Console.WriteLine();

        Console.WriteLine("Remove duplicates with groupby and select linq method");
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.WithGroupByAndSelectLINQMethod(arrayWithDuplicateValues)));
        Console.WriteLine();

        Console.WriteLine("Remove duplicates with hashset linq method");
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.ByHashing(arrayWithDuplicateValues)));
        Console.WriteLine();

        Console.WriteLine("Remove duplicates by creating an hashset from the array");
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.ByCreatingHashSet(arrayWithDuplicateValues)));
        Console.WriteLine();

        Console.WriteLine("Remove duplicates with for loop by shifting elements in the array");
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.UsingForLoopAndShiftingElements(arrayWithDuplicateValues)));
        Console.WriteLine();

        Console.WriteLine("Remove duplicates with for loop and dictionary");
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.UsingForLoopWithDictionary(arrayWithDuplicateValues)));
        Console.WriteLine();

        Console.WriteLine("Remove duplicates with recursion and extra list");
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.UsingRecursion(arrayWithDuplicateValues)));
        Console.WriteLine();

        Console.ReadLine();
    }
}