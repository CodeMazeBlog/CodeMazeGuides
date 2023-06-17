using LibraryDemo;

public static class Program
{
    static readonly FoodOrderingModel Order = new();

    static void Main()
    {
        GenerateBillData();
        decimal BillCost = Order.GenerateBill(DiscountCalculate, ShowSumPriceWithoutDiscount);
        #region Example for Anonymous Method
        //BillCost = Order.GenerateBill(delegate (List<OrderItemModel> items, decimal OrderPrice)
        //{
        //    if (OrderPrice > 80)
        //    {
        //        return OrderPrice * 0.85M;
        //    }
        //    else if (OrderPrice > 70)
        //    {
        //        return OrderPrice * 0.80M;
        //    }
        //    else
        //    {
        //        return OrderPrice;
        //    }
        //},
        //(decimal sumPrice) => { Console.WriteLine($"Your order costs {sumPrice:C2} without the discount"); });
        #endregion
        Console.WriteLine($"The bill costs {BillCost:C2}");
        Console.WriteLine("Press any key to close application");
        Console.ReadKey();
    }

    public static void ShowSumPriceWithoutDiscount(decimal sumPrice)
    {
        Console.WriteLine($"Your order costs {sumPrice:C2} without the discount");
    }

    public static decimal DiscountCalculate(List<OrderItemModel> items, decimal orderPrice)
    {
        if (orderPrice is 0)
        {
            throw new ArgumentNullException("OrderPrice");
        }
        else
        {
            if (orderPrice > 80)
            {
                return orderPrice * 0.85M;
            }
            else if (orderPrice > 70)
            {
                return orderPrice * 0.80M;
            }
            else
            {
                return orderPrice;
            }
        }
    }

    /// Generate demo data in the bill
    private static void GenerateBillData()
    {
        Order.Items.Add(new OrderItemModel { Name = "Mushroom Soap", Price = 15.5M });
        Order.Items.Add(new OrderItemModel { Name = "Chiken Salad", Price = 20.3M });
        Order.Items.Add(new OrderItemModel { Name = "Vegetarian Pizza", Price = 30M });
        Order.Items.Add(new OrderItemModel { Name = "Banana Pancake", Price = 10M });
        Order.Items.Add(new OrderItemModel { Name = "Lemon Tea", Price = 13.5M });
    }

}



