using ActionAndFuncDemo.BusinessModels;

namespace ActionAndFuncDemo.BusinessProcesses
{
    public class DisplayProcesses
    {
        /// <summary>
        /// Method to display the cart values
        /// </summary>
        /// <param name="cart"></param>
        public static void DisplayCart(Cart cart)
        {
            foreach (var purchasedItem in cart.CartItems)
            {
                Console.WriteLine($"Item Name: {purchasedItem.ItemName}");
                Console.WriteLine($"Price: ${purchasedItem.PurchasedPrice}");
                Console.WriteLine($"Quantity: {purchasedItem.PurchasedQuantity}");
                Console.WriteLine("--");
            }
            Console.WriteLine();
            Console.WriteLine($"G.Total:{cart.GrandTotal}");
        }
    }
}
