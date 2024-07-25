using LinqWhereMethod.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LinqWhereMethod;

public static class Helper
{
    public static List<int> GetEvenNumbers()
    {
        int[] randomNumbers = [1, 5, 23, 11, 7, 2, 9, 8, 3, 6, 4, 20, 15, 0, 18, 13, 10, 33];
        var evenNumbers = randomNumbers.Where(x => x % 2 == 0).OrderBy(x => x).ToList();

        return evenNumbers;
    }

    public static List<int> GetOddNumbers()
    {
        var oddNumbers = Enumerable.Range(50, 10).Where((_, index) => index % 2 != 0).ToList();

        return oddNumbers;
    }

    public static List<Person> GetPeopleWhoseNameStartsWithD(ApplicationContext context)
    {
        var filteredPeople = context.People.Where(p => p.FirstName.ToUpper().StartsWith("D")).ToList();

        return filteredPeople;
    }

    public static List<Person> GetPeopleBornFrom1974(ApplicationContext context)
    {
        IQueryable<Person> queryResult = context.People.Where(p => p.BirthDate.Year >= 1974);

        return queryResult.ToList();
    }

    public static List<Person> GetPeopleUsingChainingWhereOperators(ApplicationContext context)
    {
        IQueryable<Person> result = context.People
            .Include(person => person.Address)
            .Where(s => s.BirthDate.Year < 1974)
            .Where(s => s.Address.City.Equals("NANCY"));

        return result.ToList();
    }

    public static List<Person> GetPeopleUsingNestedWhereOperators(ApplicationContext context)
    {
        IQueryable<Person> PeopleWithAustralianShepherd = context.People
             .Include(p => p.Pets)
             .Where(person => person.Pets.Where(pet => pet.Breed.Contains("Australian")).Any(pet => pet.Name.Equals("Naïa")));

        return PeopleWithAustralianShepherd.ToList();
    }

    public static List<Person> GetPeopleUsingExpression(ApplicationContext context)
    {
        Expression<Func<Person, bool>> HasAustralianShepherds = p => p.Pets.Any(pet => pet.Breed.Equals("Australian Shepherd") && pet.Name.Equals("Naïa"));
        var filteredResult = context.People.Where(HasAustralianShepherds);

        return filteredResult.ToList();
    }

}
