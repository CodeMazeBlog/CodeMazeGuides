using AutoMapper;
using CodeMazeShop.Grpc;

namespace CodeMazeShop.Services.ShoppingCart.Facade;

public class DiscountFacade : IDiscountFacade
{ 
    private readonly Discounts.DiscountsClient _discountClient;
    private readonly IMapper _mapper;

    public DiscountFacade(Discounts.DiscountsClient discountClient, IMapper mapper)
    {
        _discountClient = discountClient;
        _mapper = mapper;
    }
    
    public async Task<Entities.PromotionCoupon> GetPromotionCouponByCode(string code)
    {
        var getCouponByCodeRequest = new GetCouponByCodeRequest { CouponCode = code };
        var getCouponByCodeResponse = await _discountClient.GetCouponByCodeAsync(getCouponByCodeRequest);

        return _mapper.Map<Entities.PromotionCoupon>(getCouponByCodeResponse.Coupon);
    }

    public async Task<Entities.PromotionCoupon> GetPromotionCouponById(string id)
    {
        var getCouponByIdRequest = new GetCouponByIdRequest { CouponId = id };
        var getCouponByIdResponse = await _discountClient.GetCouponByIdAsync(getCouponByIdRequest);

        return _mapper.Map<Entities.PromotionCoupon>(getCouponByIdResponse.Coupon);
    }

    public async Task UpdatePromotionCodeSatus(string couponId)
    {
        var updateCouponStatusRequest = new UpdateCouponStatusRequest { CouponId = couponId };
        await _discountClient.UpdateCouponStatusAsync(updateCouponStatusRequest);
    }
}