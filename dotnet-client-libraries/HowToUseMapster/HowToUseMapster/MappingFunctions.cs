using HowToUseMapster.Data;
using HowToUseMapster.Dtos;
using Mapster;

namespace HowToUseMapster
{
    public static class MappingFunctions
    {
        private static readonly Person _person = DemoData.CreatePerson();
        private static readonly ICollection<Person> _people = DemoData.CreatePeople();

        public static PersonDto MapPersonToNewDto()
        {
            var personDto = _person.Adapt<PersonDto>();

            return personDto;
        }

        public static PersonDto MapPersonToExistingDto()
        {
            var personDto = new PersonDto();
            _person.Adapt(personDto);

            return personDto;
        }

        public static IQueryable<PersonDto> MapPersonQueryableToDtoQueryable()
        {
            var peopleQueryable = _people.AsQueryable();
            var personDtos = peopleQueryable.ProjectToType<PersonDto>();

            return personDtos;
        }

        public static PersonShortInfoDto CustomMapPersonToShortInfoDto()
        {
            var personShortInfoDto = _person.Adapt<PersonShortInfoDto>();

            return personShortInfoDto;
        }

        public static Person MapPersonDtoToPersonEntity()
        {
            var personDto = MapPersonToNewDto();
            var person = personDto.Adapt<Person>();

            return person;
        }
    }
}
