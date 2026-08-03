using AutoMapper;

namespace AutoMapperIgnoreNullValues;

public class IgnoreNullMappingProfile : Profile
{
    public IgnoreNullMappingProfile()
    {
        CreateMap<StudentItemDto, StudentEntity>()
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.AgeInfo))
            .ForAllMembers(opts =>
            {
                opts.AllowNull();
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });

        CreateMap<StudentEntity, StudentItemDto>()
            .ForMember(dest => dest.AgeInfo, opt => opt.MapFrom(src => src.Age))
            .ForAllMembers(opts =>
            {
                opts.AllowNull();
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
    }
}

