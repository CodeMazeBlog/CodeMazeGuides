using MultipleParametersInGetMethod.Models;
using AutoMapper;

namespace MultipleParametersInGetMethod.Mapper
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
