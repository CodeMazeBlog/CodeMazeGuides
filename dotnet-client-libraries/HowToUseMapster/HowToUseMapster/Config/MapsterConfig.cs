using HowToUseMapster.Data;
using HowToUseMapster.Dtos;
using Mapster;
using System.Reflection;

namespace HowToUseMapster.Config
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Person, PersonShortInfoDto>
                .NewConfig()
                .Map(dest => dest.FullName, src => $"{src.Title} {src.FirstName} {src.LastName}")
                .Map(dest => dest.Age,
                     src => CalculateAge(DateOnly.FromDateTime(src.DateOfBirth!.Value),
                                         DateOnly.FromDateTime(DateTime.UtcNow)),
                     srcCond => srcCond.DateOfBirth.HasValue)
                .Map(dest => dest.FullAddress, src => $"{src.Address.Street} {src.Address.PostCode} - {src.Address.City}");

            TypeAdapterConfig<Person, PersonDto>
                .NewConfig()
                .Ignore(dest => dest.Title)
                .TwoWays();

            TypeAdapterConfig<Person, PersonDto>.ForType()
                .BeforeMapping((src, result) => result.SayHello())
                .AfterMapping((src, result) => result.SayGoodbye());

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }

        public static int CalculateAge(DateOnly birthDate, DateOnly today)
        {
            var age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
