using Bogus;
using Mapster;

namespace AutomapperVsMapster.AttributeMapping.Mapster;
public class MapsterAttributeMapping
{
    public static UserDto Map(User source)
    {
        var destination = source.Adapt<UserDto>();

        return destination;
    }

    public static User GetSource()
    {
        var faker = new Faker<User>()
            .Rules((f, o) =>
            {
                o.Id = f.Random.Number();
                o.FirstName = f.Name.FirstName();
                o.LastName = f.Name.LastName();
                o.Email = f.Person.Email;
                o.CreatedAt = DateTime.Now;
            });
        return faker.Generate();
    }
}
