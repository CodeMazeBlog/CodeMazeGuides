using HowToUseMapster;
using HowToUseMapster.Config;
using HowToUseMapster.Data;
using System;
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

        [Fact]
        public void GivenBirthdayAlreadyPassedThisYear_WhenCalculateAge_ThenReturnsFullYears()
        {
            var birthDate = new DateOnly(1990, 1, 1);
            var today = new DateOnly(2026, 8, 15);

            var age = MapsterConfig.CalculateAge(birthDate, today);

            Assert.Equal(36, age);
        }

        [Fact]
        public void GivenLeapDayBirthdayInNonLeapYear_WhenCalculateAgeBeforeMarch_ThenBirthdayNotYetCounted()
        {
            var birthDate = new DateOnly(2000, 2, 29);
            var today = new DateOnly(2025, 2, 28);

            var age = MapsterConfig.CalculateAge(birthDate, today);

            Assert.Equal(24, age);
        }
    }
}