namespace CodeMazeShop.DataContracts.Discount;

public class PromotionCoupon
{
    public Guid PromotionCouponId { get; set; }
    public string Code { get; set; }
    public int Amount { get; set; }
    public bool IsAlreadyUsed { get; set; }
}
