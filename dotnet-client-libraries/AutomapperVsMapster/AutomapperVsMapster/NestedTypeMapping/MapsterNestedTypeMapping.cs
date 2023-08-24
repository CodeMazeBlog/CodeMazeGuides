using Mapster;

namespace AutomapperVsMapster.NestedTypeMapping;
public class MapsterNestedTypeMapping
{
    public static UserDto Map(User source)
    {
        var destination = source.Adapt<UserDto>();

        return destination;
    }
}
