using DtoVsPoco.Domain;
using DtoVsPoco.Dtos;
using DtoVsPoco.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests;

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

    [Fact]
    public async Task WhenGettingPersonDetailsData_ThenPocoValuesAreCopiedToDtos()
    {
        var personDetailsData = await _personService.GetPersonDetailsData();
        var first = personDetailsData.First();

        Assert.Equal(new PersonDetails("Bruce", "Wayne", "DC Street 22", new DateTime(1972, 7, 8)), first);
    }

    [Fact]
    public void GivenPersonWhoTurns21Tomorrow_WhenCheckingIsAdult_ThenReturnFalse()
    {
        var person = new Person(4) { DateOfBirth = DateTime.Today.AddYears(-21).AddDays(1) };

        Assert.False(person.IsAdult());
    }

    [Fact]
    public void GivenPersonWhoTurns21Today_WhenCheckingIsAdult_ThenReturnTrue()
    {
        var person = new Person(5) { DateOfBirth = DateTime.Today.AddYears(-21) };

        Assert.True(person.IsAdult());
    }
}
