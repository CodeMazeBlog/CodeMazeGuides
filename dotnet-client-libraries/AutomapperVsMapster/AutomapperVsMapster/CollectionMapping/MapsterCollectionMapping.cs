using Mapster;

namespace AutomapperVsMapster.CollectionMapping;
public class MapsterCollectionMapping
{
    public static List<UserDto> Map(List<User> source)
    {
        var destination = source.Adapt<List<UserDto>>();

        return destination;
    }
}
