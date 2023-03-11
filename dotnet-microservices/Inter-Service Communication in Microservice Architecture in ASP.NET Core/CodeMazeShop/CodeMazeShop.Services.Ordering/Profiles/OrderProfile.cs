using AutoMapper;

namespace CodeMazeShop.Services.Ordering.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Entities.Order, DataContracts.Ordering.Order>()
                .ForMember(dest => dest.OrderId, opts => opts.MapFrom(src => new Guid(src.OrderId)))
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => new Guid(src.UserId)));                
    }
}
