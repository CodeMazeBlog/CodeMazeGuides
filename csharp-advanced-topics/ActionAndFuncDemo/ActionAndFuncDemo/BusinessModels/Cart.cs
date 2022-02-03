namespace ActionAndFuncDemo.BusinessModels
{
    /// <summary>
    /// Model to hold the cart data
    /// </summary>
    public class Cart
    {

        public Cart(string customerName)
        {
            CustomerName = customerName;
        }
        /// <summary>
        /// Name of the customer purchasing items
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Grand Total of the bill
        /// </summary>
        public decimal GrandTotal { get; set; }
        /// <summary>
        /// List of items present in the cart (purchased by the customer)
        /// </summary>
        public List<CartItem> CartItems { get; set; }
    }
}
