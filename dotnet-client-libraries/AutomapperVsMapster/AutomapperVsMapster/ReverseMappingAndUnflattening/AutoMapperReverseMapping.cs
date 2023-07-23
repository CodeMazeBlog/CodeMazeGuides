using AutoMapper;

namespace AutomapperVsMapster.ReverseMappingAndUnflattening;
public class AutoMapperReverseMapping
{
    public static IMapper Mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>()
                .ForMember(dest => dest.EmailAddress, config => config.MapFrom(src => src.Email))
                .ReverseMap();
        })
        .CreateMapper();

    public static User Map(UserDto destination)
    {
        var source = Mapper.Map<User>(destination);

        return source;
    }
}
