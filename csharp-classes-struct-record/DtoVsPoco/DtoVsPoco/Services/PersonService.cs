using DtoVsPoco.DataStore;
using DtoVsPoco.Dtos;
using Mapster;

namespace DtoVsPoco.Services;

public class PersonService : IPersonService
{
    public Task<ICollection<PersonDetails>> GetPersonDetailsData()
    {
        var people = FakeDataStore.GetPersonDomainObjects();
        var personDetailsDtos = people.Adapt<ICollection<PersonDetails>>();

        return Task.FromResult(personDetailsDtos);
    }
}
