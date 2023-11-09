using Mapster;

namespace AutomapperVsMapster.CustomPropertyMapping;
public class MapsterCustomPropertyMapping
{
    public static void Initialize()
    {
        TypeAdapterConfig<User, UserDto>
            .NewConfig()
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");
    }

    public static UserDto Map(User source)
    {
        var destination = source.Adapt<UserDto>();

        return destination;
    }
}
