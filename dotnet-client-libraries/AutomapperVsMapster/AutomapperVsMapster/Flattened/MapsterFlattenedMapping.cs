using Mapster;

namespace AutomapperVsMapster.Flattened;
public class MapsterFlattenedMapping
{
    public static UserDto Map(User source)
    {
        var destination = source.Adapt<UserDto>();

        return destination;
    }
}
