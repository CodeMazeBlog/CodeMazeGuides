using Mapster;

namespace AutomapperVsMapster.ReverseMappingAndUnflattening;
public class MapsterReverseMapping
{
    public static void Initialize()
    {
        TypeAdapterConfig<User, UserDto>
            .NewConfig()
            .TwoWays()
            .Map(dest => dest.EmailAddress, src => src.Email);
    }

    public static User Map(UserDto destination)
    {
        var source = destination.Adapt<User>();

        return source;
    }
}
