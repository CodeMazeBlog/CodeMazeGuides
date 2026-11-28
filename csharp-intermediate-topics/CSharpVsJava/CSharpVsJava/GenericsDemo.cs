namespace CSharpVsJava;

public static class GenericsDemo
{
    public static void Run()
    {
        var quantities = new List<int> { 3, 1, 2 };
        var customers = new List<string> { "Ann", "Bob" };

        Console.WriteLine(quantities.GetType());
        Console.WriteLine(quantities.GetType() == customers.GetType());
        Console.WriteLine(Describe(quantities));
    }

    private static string Describe<T>(List<T> items) => $"{items.Count} items of type {typeof(T).Name}";
}
