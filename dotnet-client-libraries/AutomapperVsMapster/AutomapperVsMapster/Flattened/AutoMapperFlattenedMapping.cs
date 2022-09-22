using AutoMapper;

namespace AutomapperVsMapster.Flattened;
public class AutoMapperFlattenedMapping
{
    public static IMapper Mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>();
        })
        .CreateMapper();

    public static UserDto Map(User source)
    {
        var destination = Mapper.Map<UserDto>(source);

        return destination;
    }
}
