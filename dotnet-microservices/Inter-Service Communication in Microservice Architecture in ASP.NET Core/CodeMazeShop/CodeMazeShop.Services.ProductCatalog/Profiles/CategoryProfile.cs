using AutoMapper;
using DataContract = CodeMazeShop.DataContracts.ProductCatalog;

namespace CodeMazeShop.Services.ProductCatalog.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, DataContract.Category>()
                .ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => new Guid(src.CategoryId)));
        }
    }
}
