namespace ParamsKeyword;

public class Basket
{
    public void Store(params string[] items)
        => Console.WriteLine($"Array overload: {items.Length} items");

    public void Store(params ReadOnlySpan<string> items)
        => Console.WriteLine($"Span overload: {items.Length} items");
}
