using FuncAndActionDelegates.DTO;
using FuncAndActionDelegates.Global;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter customer name: ");
        var customerName = Console.ReadLine();

        int loyaltyPoints;
        do
        {
            Console.Write("Enter loyalty points: ");
        } while (!int.TryParse(Console.ReadLine(), out loyaltyPoints));

        Console.Write("Enter total amount: ");
        double totalAmount;
        while (!double.TryParse(Console.ReadLine(), out totalAmount)) ;

        var customer = new Customer { Name = customerName, LoyaltyPoints = loyaltyPoints };
        var order = new Order { Customer = customer, TotalAmount = totalAmount };
        CheckOrderForDiscount(order);
    }

    public  static void  CheckOrderForDiscount (Order order )
    {
        Func<Order, double> calculateDiscountFunc = DiscountHelper.CalculateDiscount;
        double discount = calculateDiscountFunc(order);
        if (discount > 0)
        {
        Console.WriteLine($"Congrats! {order.Customer.Name} on your Discount\n" +
                          $"Your new billing amount is ${discount}");
        }
        // Using Action delegate to print the thank you message
        Action<Order> printThankYouAction = DiscountHelper.PrintThankYouMessage; 
        printThankYouAction(order);
    } 

}