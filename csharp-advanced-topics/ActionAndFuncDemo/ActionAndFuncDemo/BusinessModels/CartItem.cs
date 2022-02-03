namespace ActionAndFuncDemo.BusinessModels
{
    /// <summary>
    /// Holds the data for a cart item (item purchased by the customer)
    /// </summary>
    public class CartItem
    {
        public CartItem(int itemId, string itemName, decimal purchasedPrice, decimal purchasedQuantity, Metrics purchasedMetric)
        {
            ItemId = itemId;
            PurchasedPrice = purchasedPrice;
            PurchasedQuantity = purchasedQuantity;
            PurchasedMetric = purchasedMetric;
            ItemName = itemName;
        }

        /// <summary>
        /// Unique id for the purchased item for the reference
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// Name of the item
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Price of the item on which customer purchased the item
        /// </summary>
        public decimal PurchasedPrice { get; set; }
        /// <summary>
        /// Quantity of the item on which customer purchased the item
        /// </summary>
        public decimal PurchasedQuantity { get; set; }
    }
}
