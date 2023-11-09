using AutoMapper;

namespace AutomapperVsMapster.CustomPropertyMapping;
public class AutoMapperCustomPropertyMapping
{
    public static IMapper Mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>()
            .ForMember(
                dest => dest.FullName,
                config => config.MapFrom(src => $"{src.FirstName} {src.LastName}"
            ));
        })
        .CreateMapper();

    public static UserDto Map(User source)
    {
        var destination = Mapper.Map<UserDto>(source);

        return destination;
    }
}
