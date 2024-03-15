using AutoMapper;
using CodeMazeShop.DataContracts.Discount;
using CodeMazeShop.Services.Discount.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CodeMazeShop.Services.Discount.Controllers;

[Route("api/coupon")]
[ApiController]
public class CouponController : ControllerBase
{ 
    private readonly ICouponRepository _couponRepository;
    private readonly IMapper _mapper;

    public CouponController(ICouponRepository couponRepository, IMapper mapper)
    {
        _couponRepository = couponRepository;
        _mapper = mapper;
    }

    [HttpGet("code/{code}")]
    public async Task<ActionResult<PromotionCoupon>> GetCouponByCode(string code) 
        => Ok(_mapper.Map<PromotionCoupon>( await _couponRepository.GetPromotionCouponByCode(code)));

    [HttpGet("{couponId}")]
    public async Task<ActionResult<PromotionCoupon>> GetCouponById(string couponId) 
        => Ok(_mapper.Map<PromotionCoupon>(await _couponRepository.GetPromotionCouponById(couponId)));

    [HttpPut("{couponId}")]
    public async Task<ActionResult<PromotionCoupon>> UpdateCouponStatus(string couponId)
    {
        await _couponRepository.UpdatePromotionCodeSatus(couponId);
        return NoContent();
    }
}