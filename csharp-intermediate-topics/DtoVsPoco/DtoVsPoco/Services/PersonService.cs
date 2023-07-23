using DtoVsPoco.DataStore;
using DtoVsPoco.Dtos;
using Mapster;

namespace DtoVsPoco.Services
{
    public class PersonService: IPersonService
    {
        public async Task<ICollection<PersonDetails>> GetPersonDetailsData()
        {
            var people = FakeDataStore.GetPersonDomainObjects();
            var personDetailsDtos = people.Adapt<ICollection<PersonDetails>>();

            return await Task.FromResult(personDetailsDtos);
        }
    }
}
