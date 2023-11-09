namespace LINQSortingAndFiltering;

public static class Extensions
{
    public static void PrintList(this IEnumerable<Shape?> shapes)
    {
        Console.WriteLine("----------------------------------------");
        foreach (var shape in shapes)
            Console.WriteLine(shape?.ToString() ?? "Null Shape");
        Console.WriteLine("----------------------------------------");
    }
}