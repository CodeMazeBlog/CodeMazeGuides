using LinqWhereMethod;
using LinqWhereMethod.Models;
using Microsoft.EntityFrameworkCore;

namespace TestLinqWhereMethod;

public class UnitTests
{
    [Fact]
    public void GivenAListOfNumbers_WhenFiltering_ThenReturnEvenNumbers()
    {
        // Arrange & Act
        var evenNumbers = Helper.GetEvenNumbers();

        // Assert
        Assert.All(evenNumbers, n => Assert.True(n % 2 == 0));
    }

    [Fact]
    public void GivenAListOfNumbers_WhenFiltering_ThenReturnOddNumbers()
    {
        // Arrange & Act
        var oddNumbers = Helper.GetOddNumbers();

        // Assert
        Assert.All(oddNumbers, n => Assert.True(n % 2 != 0));
    }

    [Fact]
    public void GivenPeopleRecordsInDatabase_WhenFiltering_ThenReturnPeopleBornFrom1974()
    {
        // Arrange
        ApplicationContext context = GetMemoryContext();
        context.Database.EnsureCreated();

        // Act           
        var peopleBornFrom1974 = Helper.GetPeopleBornFrom1974(context);

        // Assert
        Assert.All(peopleBornFrom1974, p => Assert.True(p.BirthDate.Year >= 1974));
        Assert.Collection(peopleBornFrom1974, item => Assert.Contains("JACKSON Colleen", $"{item.LastName} {item.FirstName}"),
                                                       item => Assert.Contains("RICHARD Dan", $"{item.LastName} {item.FirstName}"));
        Assert.Equal(2, peopleBornFrom1974.Count);
    }

    [Fact]
    public void GivenPeopleRecordsInDatabase_WhenFiltering_ThenReturnPeopleBornBefore1974AndLivingInNancy()
    {
        // Arrange
        ApplicationContext context = GetMemoryContext();
        context.Database.EnsureCreated();

        // Act
        var peopleBornBefore1974LivingInNancy = Helper.GetPeopleUsingChainingWhereOperators(context);

        // Assert
        Assert.All(peopleBornBefore1974LivingInNancy, p => Assert.True(p.BirthDate.Year <= 1974 && p.Address.City.Equals("NANCY")));
        Assert.Single(peopleBornBefore1974LivingInNancy);
    }

    [Fact]
    public void GivenPeopleRecordsInDatabase_WhenFiltering_ThenReturnPeopleWithAustralianShepherdPet()
    {
        // Arrange
        ApplicationContext context = GetMemoryContext();
        context.Database.EnsureCreated();

        // Act
        var peopleWithAustralianShepherdPetUsingNestedOperators = Helper.GetPeopleUsingNestedWhereOperators(context);
        var peopleWithAustralianShepherdPetUsingExpression = Helper.GetPeopleUsingExpression(context);


        // Assert
        Assert.Collection(peopleWithAustralianShepherdPetUsingNestedOperators, item => Assert.Contains("RICHARD Dan", $"{item.LastName} {item.FirstName}"));
        Assert.Single(peopleWithAustralianShepherdPetUsingNestedOperators);

        Assert.Collection(peopleWithAustralianShepherdPetUsingExpression, item => Assert.Contains("RICHARD Dan", $"{item.LastName} {item.FirstName}"));
        Assert.Single(peopleWithAustralianShepherdPetUsingExpression);
    }

    public static ApplicationContext GetMemoryContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseInMemoryDatabase(databaseName: "PeopleDatabase")
        .Options;
        return new ApplicationContext(options);
    }
}