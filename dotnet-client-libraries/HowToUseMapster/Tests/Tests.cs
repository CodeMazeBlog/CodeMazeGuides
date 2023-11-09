using HowToUseMapster;
using HowToUseMapster.Data;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly Person _person = DemoData.CreatePerson();
        private readonly ICollection<Person> _people = DemoData.CreatePeople();

        [Fact]
        public void WhenMappingPersonToNewDto_ThenDtoNotNullAndFirstNameIsEqual()
        {
            var newDto = MappingFunctions.MapPersonToNewDto();

            Assert.NotNull(newDto);
            Assert.Equal(_person.FirstName, newDto.FirstName);
        }

        [Fact]
        public void WhenMappingPersonToExistingDto_ThenDtoNotNullAndFirstNameIsEqual()
        {
            var existingDto = MappingFunctions.MapPersonToExistingDto();

            Assert.NotNull(existingDto);
            Assert.Equal(_person.FirstName, existingDto.FirstName);
        }

        [Fact]
        public void WhenMappingPersonQueryableToDtoQueryable_ThenDtoNotEmptyAndLengthIsEqual()
        {
            var queraybleDto = MappingFunctions.MapPersonQueryableToDtoQueryable();

            Assert.NotEmpty(queraybleDto);
            Assert.Equal(_people.Count, queraybleDto.Count());
        }

        [Fact]
        public void WhenMappingPersonDtoToPersonEntity_ThenEntityNotNullAndFirstNameIsEqual()
        {
            var entity = MappingFunctions.MapPersonDtoToPersonEntity();

            Assert.NotNull(entity);
            Assert.Equal(_person.FirstName, entity.FirstName);
        }
    }
}