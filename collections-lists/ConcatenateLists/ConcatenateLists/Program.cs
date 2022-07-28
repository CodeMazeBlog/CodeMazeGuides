namespace ConcatenateLists;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("---------- Concatenate Lists in C# ----------");

        var firstList = new List<string>() { "Code", "Maze", "Concatenate" };
        var secondList = new List<string>() { "Lists", "in", "C#" };

        var concatenator = new Concatenator();

        Console.WriteLine();
        Console.WriteLine("------ Concatenate lists using Add");
        PrintOut(concatenator.UsingAdd(firstList, secondList));

        Console.WriteLine();
        Console.WriteLine("------ Concatenate using Enumerable.Concat");
        PrintOut(concatenator.UsingEnumerableConcat(firstList, secondList));

        Console.WriteLine();
        Console.WriteLine("------ Concatenate using Enumerable.Union");
        PrintOut(concatenator.UsingEnumerableUnion(firstList, secondList));

        Console.WriteLine();
        Console.WriteLine("------ Concatenate using AddRange");
        PrintOut(concatenator.UsingAddRange(firstList, secondList));

        Console.WriteLine();
        Console.WriteLine("------ Concatenate using List CopyTo");
        PrintOut(concatenator.UsingCopyTo(firstList, secondList));

        Console.WriteLine();
        Console.WriteLine("------ Concatenate using SelectMany");
        PrintOut(concatenator.UsingSelectMany(firstList, secondList));

        Console.ReadLine();
    }

    private static void PrintOut(List<string> list)
    {
        list.ForEach(x => Console.Write($" => {x}"));
        Console.WriteLine();
    }
}
