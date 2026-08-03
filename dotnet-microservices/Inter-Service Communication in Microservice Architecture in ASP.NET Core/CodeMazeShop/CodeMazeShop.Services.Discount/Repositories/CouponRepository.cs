using CodeMazeShop.Services.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeMazeShop.Services.Discount.Repositories;

public class CouponRepository : ICouponRepository
{
    private readonly CouponContext _context;

    public CouponRepository(CouponContext context)
    {
        _context = context;   
    }

    public async Task<PromotionCoupon> GetPromotionCouponByCode(string code)
        => await _context.PromotionCoupons.FirstOrDefaultAsync(pc => pc.Code == code);


    public async Task<PromotionCoupon> GetPromotionCouponById(string id)
         => await _context.PromotionCoupons.FirstOrDefaultAsync(pc => pc.PromotionCouponId == id);

    public async Task UpdatePromotionCodeSatus(string couponId)
    {
        var coupon = await _context.PromotionCoupons.FirstOrDefaultAsync(pc => pc.PromotionCouponId == couponId);
        coupon.IsAlreadyUsed = true;
        await _context.SaveChangesAsync();
    }
}
