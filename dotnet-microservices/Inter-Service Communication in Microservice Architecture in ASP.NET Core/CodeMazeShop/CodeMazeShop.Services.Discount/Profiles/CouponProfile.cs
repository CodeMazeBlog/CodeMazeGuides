using AutoMapper;
using DataContract = CodeMazeShop.DataContracts.Discount;

namespace CodeMazeShop.Services.Discount.Profiles;

public class CouponProfile : Profile
{
    public CouponProfile()
    {
        CreateMap<Entities.PromotionCoupon, DataContract.PromotionCoupon>()
               .ForMember(dest => dest.PromotionCouponId, opts => opts.MapFrom(src => new Guid(src.PromotionCouponId)));

        CreateMap<Entities.PromotionCoupon, Grpc.PromotionCoupon>();
        
    }
   
}
