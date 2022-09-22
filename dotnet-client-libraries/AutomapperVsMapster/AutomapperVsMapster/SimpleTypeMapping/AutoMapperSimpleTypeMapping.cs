using AutoMapper;

namespace AutomapperVsMapster.SimpleTypeMapping;
public class AutoMapperSimpleTypeMapping
{
    public static IMapper Mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>()).CreateMapper();

    public static UserDto Map(User source)
    {
        var destination = Mapper.Map<UserDto>(source);

        return destination;
    }
}