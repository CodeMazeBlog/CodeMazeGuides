using CodeMazeShop.Services.ShoppingCart.Entities;

namespace CodeMazeShop.Services.ShoppingCart.Facade;

public interface IDiscountFacade
{
    Task<PromotionCoupon> GetPromotionCouponByCode(string code);
    
    Task<PromotionCoupon> GetPromotionCouponById(string id);

    Task UpdatePromotionCodeSatus(string couponId);

}