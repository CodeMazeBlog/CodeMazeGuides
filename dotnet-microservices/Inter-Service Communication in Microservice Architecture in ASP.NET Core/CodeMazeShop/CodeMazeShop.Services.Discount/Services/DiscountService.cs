using AutoMapper;
using CodeMazeShop.Grpc;
using CodeMazeShop.Services.Discount.Repositories;
using Grpc.Core;

namespace CodeMazeShop.Services.Discount.Services;

public class DiscountService : Discounts.DiscountsBase
{
	private readonly ICouponRepository _couponRepository;
	private readonly IMapper _mapper;

	public DiscountService(ICouponRepository couponRepository, IMapper mapper)
	{
		_couponRepository = couponRepository;
		_mapper = mapper;
	}

    public override async Task<GetCouponByIdResponse> GetCouponById(GetCouponByIdRequest request, ServerCallContext context)
    {
		var response = new GetCouponByIdResponse();
		var coupon = await _couponRepository.GetPromotionCouponById(request.CouponId);

		response.Coupon = _mapper.Map<Grpc.PromotionCoupon>(coupon);
		
		return response;
    }

    public override async Task<GetCouponByCodeResponse> GetCouponByCode(GetCouponByCodeRequest request, ServerCallContext context)
    {
        var response = new GetCouponByCodeResponse();
        var coupon = await _couponRepository.GetPromotionCouponByCode(request.CouponCode);

        response.Coupon = _mapper.Map<Grpc.PromotionCoupon>(coupon);

        return response;
    }

    public override async Task<UpdateCouponStatusResponse> UpdateCouponStatus(UpdateCouponStatusRequest request, ServerCallContext context)
    {
        var response = new UpdateCouponStatusResponse();
        try
        {
            await _couponRepository.UpdatePromotionCodeSatus(request.CouponId);
            response.Success = true;
        }
        catch
        {
            response.Success = false;
        }

        return response;
    }
}
