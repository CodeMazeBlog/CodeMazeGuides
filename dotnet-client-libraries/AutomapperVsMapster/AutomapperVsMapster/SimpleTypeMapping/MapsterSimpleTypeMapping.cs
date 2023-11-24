using Mapster;

namespace AutomapperVsMapster.SimpleTypeMapping;
public class MapsterSimpleTypeMapping
{
    public static UserDto Map(User source)
    {
        var destination = source.Adapt<UserDto>();

        return destination;
    }
}
