using Bogus;

namespace AutomapperVsMapster.ReverseMappingAndUnflattening;
public class ReverseMappingDataGenerator
{
    public static List<UserDto> GetSources(int count = 1000)
    {
        var faker = new Faker<UserDto>()
            .Rules((f, o) =>
            {
                o.Id = f.Random.Number();
                o.FirstName = f.Name.FirstName();
                o.LastName = f.Name.LastName();
                o.EmailAddress = f.Person.Email;
                o.AddressAddressLine1 = f.Address.BuildingNumber();
                o.AddressAddressLine2 = f.Address.CardinalDirection();
                o.AddressCity = f.Address.City();
                o.AddressState = f.Address.State();
                o.AddressCountry = f.Address.Country();
                o.AddressZipCode = f.Address.ZipCode();
            });
        return faker.Generate(count);
    }
}
