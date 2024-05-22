using AutoMapper;

namespace AutoMapperIgnoreProperty;

public class MapperHelper
{
    public static IMapper GetMapperIgnoringSensitiveProperties()
    {
        var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<User, UserDto>()
               .ForMember(dest => dest.Password, opt => opt.Ignore())
               .ForMember(dest => dest.IsAdmin, opt => opt.Ignore()));

        return configuration.CreateMapper();
    }

    public static IMapper GetMapperIgnoringSensitivePropertiesWithAttribute()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(Program).Assembly));
        return configuration.CreateMapper();
    }

    public static IMapper GetMapperIgnoringSourceMembers()
    {
        var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<User, UserDto>(MemberList.Source)
               .ForSourceMember(source => source.Email, opt => opt.DoNotValidate()));

        configuration.AssertConfigurationIsValid();

        return configuration.CreateMapper();
    }
}