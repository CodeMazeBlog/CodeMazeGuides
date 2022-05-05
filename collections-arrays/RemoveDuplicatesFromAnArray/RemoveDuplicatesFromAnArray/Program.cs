namespace RemoveDuplicatesFromAnArray;

class Program
{
    public static readonly RemoveDuplicateElements _duplicatesRemoval = new RemoveDuplicateElements();

    static void Main(string[] args)
    {
        var array = Enumerable.Repeat("Lovely", 2).Concat(Enumerable.Repeat("Boy", 2)).Concat(Enumerable.Repeat("Lovely", 2)).ToArray();

        Console.WriteLine("Remove duplicates with distinct linq method");
        Console.WriteLine("Input = {0}", string.Join(",",array));
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.WithDistinct_Method(array)));
        Console.WriteLine();

        array = Enumerable.Repeat("Lovely", 2).Concat(Enumerable.Repeat("Boy", 2)).Concat(Enumerable.Repeat("Lovely", 2)).ToArray();
        Console.WriteLine("Remove duplicates with groupby and select linq method");
        Console.WriteLine("Input = {0}", string.Join(",", array));
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.WithGroupByandSelect(array)));
        Console.WriteLine();

        array = Enumerable.Repeat("Lovely", 2).Concat(Enumerable.Repeat("Boy", 2)).Concat(Enumerable.Repeat("Lovely", 2)).ToArray();
        Console.WriteLine("Remove duplicates with hashset linq method");
        Console.WriteLine("Input = {0}", string.Join(",", array));
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.ByHashing(array)));
        Console.WriteLine();

        array = Enumerable.Repeat("Lovely", 2).Concat(Enumerable.Repeat("Boy", 2)).Concat(Enumerable.Repeat("Lovely", 2)).ToArray();
        Console.WriteLine("Remove duplicates by creating an hashset from the array");
        Console.WriteLine("Input = {0}", string.Join(",", array));
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.ByCreatingHashSet(array)));
        Console.WriteLine();

        array = Enumerable.Repeat("Lovely", 2).Concat(Enumerable.Repeat("Boy", 2)).Concat(Enumerable.Repeat("Lovely", 2)).ToArray();
        Console.WriteLine("Remove duplicates with for loop by shifting elements in the array");
        Console.WriteLine("Input = {0}", string.Join(",", array));
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.UsingForLoop(array)));
        Console.WriteLine();

        array = Enumerable.Repeat("Lovely", 2).Concat(Enumerable.Repeat("Boy", 2)).Concat(Enumerable.Repeat("Lovely", 2)).ToArray();
        Console.WriteLine("Remove duplicates with for loop and dictionary");
        Console.WriteLine("Input = {0}", string.Join(",", array));
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.UsingForLoopWithDictionary(array)));
        Console.WriteLine();

        array = Enumerable.Repeat("Lovely", 2).Concat(Enumerable.Repeat("Boy", 2)).Concat(Enumerable.Repeat("Lovely", 2)).ToArray();
        Console.WriteLine("Remove duplicates with recursion and extra list");
        Console.WriteLine("Input = {0}", string.Join(",", array));
        Console.WriteLine("Output = {0}", string.Join(",", _duplicatesRemoval.UsingRecursion(array)));
        Console.WriteLine();

        Console.ReadLine();
    }

}