using CodeMazeShop.Services.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeMazeShop.Services.Discount;

public class CouponContext : DbContext
{
    public CouponContext(DbContextOptions<CouponContext> options)
            : base(options)
    {
    }

    public DbSet<PromotionCoupon> PromotionCoupons { get; set; }
}
