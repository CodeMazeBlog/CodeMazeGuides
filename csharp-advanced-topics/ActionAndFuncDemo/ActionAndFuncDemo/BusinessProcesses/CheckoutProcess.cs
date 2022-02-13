using ActionAndFuncDemo.BusinessModels;

namespace ActionAndFuncDemo.BusinessProcesses
{
    /// <summary>
    /// Class to hold the methods to be used while checkout
    /// </summary>
    public class CheckoutProcess
    {
        private Cart? _cart;

        /// <summary>
        /// Checkout method with calculating the discount
        /// </summary>
        /// <param name="purchasedItems">List of items purchased by the customer</param>
        /// <param name="calculateDiscount">Delegate type to provide a function to calculate discount</param>
        /// 
        /// <returns></returns>
        public void CreateCart(List<CartItem> purchasedItems, Func<Cart, decimal> calculateDiscount)
        {
            var cart = new Cart();
            var gTotal = 0.0m;
            foreach (var purchasedItem in purchasedItems)
            {
                var total = purchasedItem.PurchasedPrice * purchasedItem.PurchasedQuantity;
                gTotal += total;
            }
            cart.CartItems = purchasedItems;
            cart.GrandTotal = decimal.Round(gTotal, 2);
            //calling the method provided as a parameter into this function, the reason of making this func type delegate is to minimize the dependency, as we know requirements changes rapidly, so using the SOLID principle everytime we can not do a change each and everytime in this method. So we have taken the method as a parameter and everytime when the requirements change we would have to change into that provided method only.
            var discount = calculateDiscount(cart);
            //applying discount into the grandtotal
            cart.GrandTotal -= discount;
            _cart = cart;
        }

        public void GetCartValues(Action<Cart> displayAction)
        {
            displayAction(_cart);
        }
    }
}
