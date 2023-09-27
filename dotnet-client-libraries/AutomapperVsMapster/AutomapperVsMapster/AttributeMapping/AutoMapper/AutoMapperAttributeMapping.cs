using AutoMapper;

namespace AutomapperVsMapster.AttributeMapping.AutoMapper;
public class AutoMapperAttributeMapping
{
    public static IMapper Mapper = new MapperConfiguration(cfg => cfg.AddMaps(typeof(AutoMapperAttributeMapping).Assembly)).CreateMapper();

    public static UserDto Map(User source)
    {
        var destination = Mapper.Map<UserDto>(source);

        return destination;
    }
}
