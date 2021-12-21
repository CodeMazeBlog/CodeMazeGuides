using System.Collections.Generic;

namespace ActionFunc
{
    /// <summary>
    /// This class handles the adding products and getting the receipt.
    /// Cart object use the methods of this class.
    /// </summary>
    public class CartManager
    {
        public List<string> Products = new();
        public Cart GetCart()
        {
            var cart = new Cart();
            cart.AddProduct = AddItem;
            cart.GetReceipt = GetReceipt;
            return cart;
        }

        public void AddItem(string name)
        {
            Products.Add(name);
        }

        public string GetReceipt(string customer)
        {
            return $"The total amount of {Products[0]} is 10$ for {customer}";
        }
    }
}
