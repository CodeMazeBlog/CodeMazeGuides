using AutoMapper;

namespace AutoMapperIgnoreNullValues;

public class DefaultMappingProfile : Profile
{
    public DefaultMappingProfile()
    {
        CreateMap<StudentItemDto, StudentEntity>()
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.AgeInfo));

        CreateMap<StudentEntity, StudentItemDto>()
            .ForMember(dest => dest.AgeInfo, opt => opt.MapFrom(src => src.Age));
    }
}

