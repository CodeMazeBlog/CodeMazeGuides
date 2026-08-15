using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;

namespace AutomapperVsMapster.NestedTypeMapping;
public class AutoMapperNestedTypeMapping
{
    public static IMapper Mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<Address, AddressDto>();
        }, NullLoggerFactory.Instance)
        .CreateMapper();

    public static UserDto Map(User source)
    {
        var destination = Mapper.Map<UserDto>(source);

        return destination;
    }
}
