using System;

namespace ActionFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            var cartManager = new CartManager();
            var cart = cartManager.GetCart();

            cart.AddProduct("tea pod");
            var receipt = cart.GetReceiptDetails("John Doe");
            Console.WriteLine(receipt);
        }
    }
}
