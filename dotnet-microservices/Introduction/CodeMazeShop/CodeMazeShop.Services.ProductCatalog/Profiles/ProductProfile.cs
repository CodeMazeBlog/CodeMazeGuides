using AutoMapper;
using DataContract = CodeMazeShop.DataContracts.ProductCatalog;

namespace CodeMazeShop.Services.ProductCatalog.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Entities.Product, DataContract.Product>()
                .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src=> new Guid(src.ProductId)))
                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.Category.CategoryId))
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
    }

}