namespace CodeMazeShop.Web.Entities;

public class Cart
{
    public Guid CartId { get; set; }
    public Guid UserId { get; set; }
    public int NumberOfItems { get; set; }
    public string? Code { get; set; }
    public int Discount { get; set; }
    public Guid? PromotionCouponId { get; set; }
}
