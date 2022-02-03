using ActionAndFuncDemo.BusinessModels;

namespace ActionAndFuncDemo.BusinessProcesses
{
    public class DiscountProcesses
    {
        public static decimal CalculateDiscount(Cart cart)
        {
            decimal discount = 0.0m;
            if (cart.GrandTotal >= 25)
            {
                discount = cart.GrandTotal * 0.3m;
            }
            else if (cart.GrandTotal >= 20)
            {
                discount = cart.GrandTotal * 0.2m;
            }
            else if (cart.GrandTotal >= 15)
            {
                discount = cart.GrandTotal * 0.1m;
            }
            else if (cart.GrandTotal >= 10)
            {
                discount = cart.GrandTotal * 0.05m;
            }
            return decimal.Round(discount, 2);
        }
    }
}
