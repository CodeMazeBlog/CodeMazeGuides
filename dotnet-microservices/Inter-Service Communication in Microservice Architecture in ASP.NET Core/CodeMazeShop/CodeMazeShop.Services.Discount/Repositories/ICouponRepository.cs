

using CodeMazeShop.Services.Discount.Entities;

namespace CodeMazeShop.Services.Discount.Repositories;

public interface ICouponRepository
{
    Task<PromotionCoupon> GetPromotionCouponByCode(string code);

    Task<PromotionCoupon> GetPromotionCouponById(string id);

    Task UpdatePromotionCodeSatus(string couponId);
}
