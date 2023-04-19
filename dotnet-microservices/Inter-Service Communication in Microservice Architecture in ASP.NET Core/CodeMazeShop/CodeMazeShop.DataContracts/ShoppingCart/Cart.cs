namespace CodeMazeShop.DataContracts.ShoppingCart;

public class Cart
{
    public Guid CartId { get; set; }
   
    public List<CartLineItem> LineItems { get; set; }
  
    public Guid? PromotionCouponId { get; set; }

    public string Code { get; set; }

    public int Discount { get; set; }

    public int ShoppingCartTotal { get; set; }  
}
