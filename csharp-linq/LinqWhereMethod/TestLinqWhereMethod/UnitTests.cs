using LinqWhereMethod.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TestLinqWhereMethod
{
    public class UnitTests
    { 
        private readonly TypeInfo program = typeof(Program).GetTypeInfo();

        [Fact]
        public void GivenAListOfNumbers_WhenFiltering_ThenReturnEvenNumbers()
        {
            // Arrange
            var evenNumbersMethod = program.DeclaredMethods.Single(m => m.Name.Contains("GetEvenNumbers"));

            // Act
            var evenNumbers = evenNumbersMethod.Invoke(null, null) as IEnumerable<int>;

            // Assert
            Assert.All<int>(evenNumbers!, n => Assert.True(n % 2 == 0));
        }

        [Fact]
        public void GivenAListOfNumbers_WhenFiltering_ThenReturnOddNumbers()
        {
            // Arrange
            var oddNumbersMethod = program.DeclaredMethods.Single(m => m.Name.Contains("GetOddNumbers"));

            // Act
            var oddNumbers = oddNumbersMethod.Invoke(null, null) as IEnumerable<int>;

            // Assert
            Assert.All<int>(oddNumbers!, n => Assert.True(n % 2 != 0));
        }

        [Fact]
        public void GivenPeopleRecordsInDatabase_WhenFiltering_ThenReturnPeopleBornFrom1974()
        {
            // Arrange
            var peopleBornFrom1974Method = program.DeclaredMethods.Single(m => m.Name.Contains("GetPeopleBornFrom1974"));
            ApplicationContext context = GetMemoryContext();
            context.Database.EnsureCreated();

            // Act           
            var peopleBornFrom1974 = peopleBornFrom1974Method.Invoke(null, new object[] { context }) as IEnumerable<Person>;

            // Assert
            Assert.All<Person>(peopleBornFrom1974!, p => Assert.True(p.BirthDate.Year >= 1974));
            Assert.Collection<Person>(peopleBornFrom1974!, item => Assert.Contains("JACKSON Colleen", $"{item.LastName} {item.FirstName}"),
                                                           item => Assert.Contains("RICHARD Dan", $"{item.LastName} {item.FirstName}"));
            Assert.Equal(2, peopleBornFrom1974?.Count());
        }

        [Fact]
        public void GivenPeopleRecordsInDatabase_WhenFiltering_ThenReturnPeopleBornBefore1974AndLivingInNancy()
        {
            // Arrange
            var peopleBornBefore1974LivingInNancyMethod = program.DeclaredMethods.Single(m => m.Name.Contains("GetPeopleUsingChainingWhereOperators"));
            ApplicationContext context = GetMemoryContext();
            context.Database.EnsureCreated();

            // Act
            var peopleBornBefore1974LivingInNancy = peopleBornBefore1974LivingInNancyMethod.Invoke(null, new object[] { context }) as IEnumerable<Person>;

            // Assert
            Assert.All<Person>(peopleBornBefore1974LivingInNancy!, p => Assert.True(p.BirthDate.Year <= 1974 && p.Address.City.Equals("NANCY")));
            Assert.Single(peopleBornBefore1974LivingInNancy!);
        }

        [Fact]
        public void GivenPeopleRecordsInDatabase_WhenFiltering_ThenReturnPeopleWithAustralianShepherdPet()
        {
            // Arrange
            var peopleWithAustralianShepherdUsingImbricatedOperatorsMethod = program.DeclaredMethods.Single(m => m.Name.Contains("GetPeopleUsingImbricatedWhereOperators"));
            var peopleWithAustralianShepherdUsingExpressionMethod = program.DeclaredMethods.Single(m => m.Name.Contains("GetPeopleUsingExpression"));
            ApplicationContext context = GetMemoryContext();
            context.Database.EnsureCreated();

            // Act
            var peopleWithAustralianShepherdPetUsingImbricatedOperators = peopleWithAustralianShepherdUsingImbricatedOperatorsMethod.Invoke(null, new object[] { context }) as IEnumerable<Person>;
            var peopleWithAustralianShepherdPetUsingExpression = peopleWithAustralianShepherdUsingExpressionMethod.Invoke(null, new object[] { context }) as IEnumerable<Person>;


            // Assert
            Assert.Collection<Person>(peopleWithAustralianShepherdPetUsingImbricatedOperators!, item => Assert.Contains("RICHARD Dan", $"{item.LastName} {item.FirstName}"));
            Assert.Single(peopleWithAustralianShepherdPetUsingImbricatedOperators!);

            Assert.Collection<Person>(peopleWithAustralianShepherdPetUsingExpression!, item => Assert.Contains("RICHARD Dan", $"{item.LastName} {item.FirstName}"));
            Assert.Single(peopleWithAustralianShepherdPetUsingExpression!);
        }

        public static ApplicationContext GetMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "PeopleDatabase")
            .Options;
            return new ApplicationContext(options);
        }
    }
}