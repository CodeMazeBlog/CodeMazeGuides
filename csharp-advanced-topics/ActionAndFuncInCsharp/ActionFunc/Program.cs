using System;

namespace ActionFunc
{
    class Program
    {
        /// <summary>
        /// In this main method, we get instance of a Cart, and use the methods.
        /// </summary>
        /// <param name="args"></param>
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
