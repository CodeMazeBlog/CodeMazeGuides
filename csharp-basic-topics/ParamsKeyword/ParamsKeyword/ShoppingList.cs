namespace ParamsKeyword;

public class ShoppingList
{
    public void Add(params string[] items)
    {
        foreach (var item in items)
        {
            Console.WriteLine($"Added: {item}");
        }
    }

    public void AddRange(params IEnumerable<string> items)
    {
        foreach (var item in items)
        {
            Console.WriteLine($"Added: {item}");
        }
    }

    public int Count(params ReadOnlySpan<string> items) => items.Length;
}
