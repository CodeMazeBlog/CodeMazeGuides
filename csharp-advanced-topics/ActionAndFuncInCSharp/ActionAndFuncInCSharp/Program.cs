namespace ActionAndFuncInCSharp;

public class Program
{
    static void Main(string[] args)
    {
        var cart = GetShoppingCart();

        Func<double, double, decimal> taxCalculator = CalculateTax;
        var tax = taxCalculator(cart.Sum(x => x.Total), 0.10);


        Action<List<CartItem>, decimal> receiptPrinter = PrintReceipt;
        receiptPrinter.Invoke(cart, tax);

        Console.ReadLine();
    }

    public static decimal CalculateTax(double total, double rate)
    {

        return Convert.ToDecimal(total * rate);
    }

    public static void PrintReceipt(List<CartItem> cart, decimal tax)
    {
        Console.WriteLine($"Product - Qty - Price - Gross");

        foreach (var item in cart)
        {

            Console.WriteLine($"{item.Name} - {item.Quantity} - {item.Price:C2} - {item.Total:C2}");
        }
        Console.WriteLine();

        Console.WriteLine($"You tax total is {tax:C2}");
    }

    public static List<CartItem> GetShoppingCart()
    {
        return new List<CartItem>
        {
            new CartItem { Name = "Milk", Price = 12, Quantity = 2 },
            new CartItem { Name = "Eggs", Price = 1.25, Quantity = 10 },
            new CartItem { Name = "Flour", Price = 8, Quantity = 1 },
            new CartItem { Name = "Cocoa", Price = 24.99, Quantity = 3 },
            new CartItem { Name = "Butter", Price = 15, Quantity = 2 }
        };
    }

}

public record CartItem
{
    public required string? Name { get; set; }
    public required double Quantity { get; set; }

    public required double Price { get; set; }

    public double Total => Quantity * Price;
}