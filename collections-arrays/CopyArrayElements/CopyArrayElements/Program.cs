namespace CopyArrayElements;

public class Program
{
    public static readonly ElementCopier elementCopier = new();
    public static int OutputResult = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("-------------------- Copying array Elements");
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("---------- Assignment approach");
        PrintArticlesTitle(elementCopier.CopyUsingAssignment(InstantiateInitialArray()));

        Console.WriteLine("---------- Array Class Approach");
        PrintArticlesTitle(elementCopier.CopyUsingArrayClass(InstantiateInitialArray()));

        Console.WriteLine("---------- Array Class Partial Copy");
        PrintArticlesTitle(elementCopier.CopyPartUsingArrayClass(InstantiateInitialArray()));

        Console.WriteLine("---------- Clone approach");
        PrintArticlesTitle(elementCopier.CopyUsingClone(InstantiateInitialArray()));

        Console.WriteLine("---------- CopyTo Approach");
        PrintArticlesTitle(elementCopier.CopyUsingCopyTo(InstantiateInitialArray()));

        Console.WriteLine("---------- Copy Using Range Approach");
        PrintArticlesTitle(elementCopier.CopyUsingRange(InstantiateInitialArray()));

        Console.WriteLine("---------- Copy Part Using Range Approach");
        PrintArticlesTitle(elementCopier.CopyPartUsingRange(InstantiateInitialArray()));

        Console.WriteLine("---------- Copy Using Span Approach");
        PrintArticlesTitle(elementCopier.CopyUsingSpan(InstantiateInitialArray()));

        Console.WriteLine("---------- Copy Using Collection Expression Approach");
        PrintArticlesTitle(elementCopier.CopyUsingCollectionExpression(InstantiateInitialArray()));

        Console.WriteLine("---------- Copy Using Linq Approach");
        PrintArticlesTitle(elementCopier.CopyUsingLinq(InstantiateInitialArray()));

        Console.WriteLine("---------- For Statement Approach");
        PrintArticlesTitle(elementCopier.ManuallyCopy(InstantiateInitialArray()));

        Console.WriteLine("---------- Shallow copy check");
        var source = InstantiateInitialArray();
        var copy = elementCopier.CopyUsingArrayClass(source);
        copy[0].Title = "Changed through the copy";
        Console.WriteLine($" -{source[0]}");
        Console.WriteLine();

        Console.WriteLine("-------------------------------------------");
        OutputResult = 1;
    }

    public static Article[] InstantiateInitialArray()
    {
        var article1 = new Article { Title = "C# Intermediate - Delegates", LastUpdate = new DateTime(2022, 11, 07) };
        var article2 = new Article { Title = "Events in C#", LastUpdate = new DateTime(2022, 01, 22) };
        var article3 = new Article { Title = "Selection Sort in C#", LastUpdate = new DateTime(2022, 01, 13) };

        return [article1, article2, article3];
    }

    public static void PrintArticlesTitle(Article[] array)
    {
        foreach (var item in array)
            Console.WriteLine($" -{item?.ToString() ?? " (empty slot)"}");

        Console.WriteLine();
    }
}
