using AutoMapper;

namespace GettingPropertyMappingsWithAutomapper;

public class MyProfile : Profile
{
    public MyProfile()
    {
        CreateMap<Source, DestinationClass>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.YearsOld, opt => opt.MapFrom(src => src.Age));
    }
}