using AutoMapper;

namespace AutomapperVsMapster.CollectionMapping;
public class AutoMapperCollectionMapping
{
    public static IMapper Mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>()).CreateMapper();

    public static List<UserDto> Map(List<User> source)
    {
        var destination = Mapper.Map<List<UserDto>>(source);

        return destination;
    }
}
