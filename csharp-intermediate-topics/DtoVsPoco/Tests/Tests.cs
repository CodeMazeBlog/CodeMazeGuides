using DtoVsPoco.Dtos;
using DtoVsPoco.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly IPersonService _personService = new PersonService();

        [Fact]
        public async Task WhenGettingPersonDetailsData_ThenReturnNotEmptyCollectionOfPersonDetailsDtos()
        {
            var personDetailsData = await _personService.GetPersonDetailsData();

            Assert.True(personDetailsData is ICollection<PersonDetails>);
            Assert.NotEmpty(personDetailsData);
        }
    }
}