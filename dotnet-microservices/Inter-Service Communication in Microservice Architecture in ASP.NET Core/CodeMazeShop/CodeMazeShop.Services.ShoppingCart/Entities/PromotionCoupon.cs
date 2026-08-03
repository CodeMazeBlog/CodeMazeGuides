namespace CodeMazeShop.Services.ShoppingCart.Entities;

public class PromotionCoupon
{
    public string PromotionCouponId { get; set; }
    public string Code { get; set; }
    public int Amount { get; set; }
    public bool IsAlreadyUsed { get; set; }
}
