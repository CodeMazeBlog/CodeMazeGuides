namespace CSharpVsJava;

public record Money(decimal Amount)
{
    public static Money operator +(Money left, Money right) => new(left.Amount + right.Amount);
}

public class Product
{
    public required string Name { get; init; }
    public required Money Price { get; set; }
}

public static class EverydayDemo
{
    public static void Run()
    {
        var lamp = new Product { Name = "Desk lamp", Price = new Money(30m) };
        lamp.Price += new Money(5m);

        Console.WriteLine($"{lamp.Name} costs {lamp.Price.Amount}");
    }
}
