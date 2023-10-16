using FuncAndActionDelegates.DTO;

namespace FuncAndActionDelegates.Global
{
   public static class DiscountHelper
    {

        public static double CalculateDiscount(Order order)
        {
            if (order.Customer.LoyaltyPoints >= 100)
            {
                return 0.2 * order.TotalAmount; // 20% discount
            }
            return 0;
        }

        public static void PrintThankYouMessage(Order order)
        {
            Console.WriteLine($"Thank you {order.Customer.Name} for using our service!");
        }
    }
}
