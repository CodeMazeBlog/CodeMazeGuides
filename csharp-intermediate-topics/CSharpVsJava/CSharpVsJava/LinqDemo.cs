namespace CSharpVsJava;

public record Order(string Customer, int Quantity);

public static class LinqDemo
{
    public static void Run()
    {
        var orders = new List<Order>
        {
            new("Ann", 3), new("Bob", 1), new("Ann", 4), new("Cid", 5), new("Bob", 2)
        };

        var totals = orders
            .GroupBy(order => order.Customer)
            .Select(group => new { Customer = group.Key, Items = group.Sum(order => order.Quantity) })
            .OrderByDescending(total => total.Items);

        foreach (var total in totals)
        {
            Console.WriteLine($"{total.Customer}: {total.Items}");
        }
    }
}
