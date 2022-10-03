using Mapster;

namespace AutomapperVsMapster.AttributeMapping.Mapster;
public class MapsterAttributeMapping
{
    public static UserDto Map(User source)
    {
        var destination = source.Adapt<UserDto>();

        return destination;
    }
}
