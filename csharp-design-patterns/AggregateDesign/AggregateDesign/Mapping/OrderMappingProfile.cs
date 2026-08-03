using AggregateDesign.DataAccess;
using AggregateDesign.Domain;
using AutoMapper;

namespace AggregateDesign.Mapping
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderModel>();

            CreateMap<OrderModel, Order>()
                .ForMember(dest => dest.Items, opt => opt.Ignore())
                .ForMember(dest => dest._items, opt => opt.MapFrom(src => src.Items));

            CreateMap<OrderItem, OrderItemModel>()
                .ReverseMap();
        }
    }
}
