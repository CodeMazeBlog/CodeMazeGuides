using AutoMapper;
using DataContract = CodeMazeShop.DataContracts.ShoppingCart;
using Messages = CodeMazeShop.Integration.Messages;

namespace CodeMazeShop.Services.ShoppingCart.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<Entities.Cart, DataContract.Cart>()
                .ForMember(dest => dest.CartId, opts => opts.MapFrom(src => new Guid(src.CartId)))
                .ForMember(dest => dest.PromotionCouponId, opts => opts.MapFrom(src => new Guid(src.PromotionCouponId)))
                .ForMember(dest => dest.Code, opts => opts.Ignore())
                .ForMember(dest => dest.Discount, opts => opts.Ignore())
                .ForMember(dest => dest.ShoppingCartTotal, opts => opts.Ignore());

            CreateMap<Entities.CartLineItem, DataContract.CartLineItem>()
                .ForMember(dest => dest.CartLineItemId, opts => opts.MapFrom(src => new Guid(src.CartLineItemId)));

            CreateMap<Entities.Product, DataContract.Product>()
                .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => new Guid(src.ProductId)));

            CreateMap<DataContract.CartLineItemForCreation, Entities.CartLineItem>()
                .ForMember(dest => dest.CartLineItemId, opts => opts.Ignore())
                .ForMember(dest => dest.Product, opts => opts.Ignore());

            CreateMap<DataContract.CartLineItemForUpdate, Entities.CartLineItem>()
               .ForMember(dest => dest.CartLineItemId, opts => opts.MapFrom(src => src.CartLineItemId.ToString()))
               .ForMember(dest => dest.Product, opts => opts.Ignore())
               .ForMember(dest => dest.Price, opts => opts.Ignore());

            CreateMap<Grpc.PromotionCoupon, Entities.PromotionCoupon>();

            CreateMap<DataContract.CheckoutRequest, Messages.CartCheckoutMessage>()
                .ForMember(dest => dest.OrderTotal, opts => opts.Ignore())
                .ForMember(dest => dest.LineItems, opts => opts.Ignore());


        }
    }
}
