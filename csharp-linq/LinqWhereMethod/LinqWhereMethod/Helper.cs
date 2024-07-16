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
        Console.WriteLine("Get odd numbers");
        var oddNumbers = Enumerable.Range(50, 10).Where((_, index) => index % 2 != 0).ToList();
        DisplayElements(oddNumbers);

        return oddNumbers;
    }

    public static List<Person> GetPeopleWhoseNameStartsWithD(ApplicationContext context)
    {
        Console.WriteLine("Get people whose firstname starts with 'D'");

        var filteredPeople = context.People.Where(p => p.FirstName.ToUpper().StartsWith("D")).ToList();
        DisplayElements(filteredPeople);

        return filteredPeople;
    }

    public static List<Person> GetPeopleBornFrom1974(ApplicationContext context)
    {
        Console.WriteLine("Get people born from 1974");

        IQueryable<Person> queryResult = context.People.Where(p => p.BirthDate.Year >= 1974);
        DisplayElements(queryResult.ToList());

        return queryResult.ToList();
    }

    public static List<Person> GetPeopleUsingChainingWhereOperators(ApplicationContext context)
    {
        Console.WriteLine("Chaining Where operators");

        IQueryable<Person> result = context.People
            .Include(person => person.Address)
            .Where(s => s.BirthDate.Year < 1974)
            .Where(s => s.Address.City.Equals("NANCY"));
        DisplayElements(result.ToList());

        return result.ToList();
    }

    public static List<Person> GetPeopleUsingNestedWhereOperators(ApplicationContext context)
    {
        Console.WriteLine("Nested Where operators");

        IQueryable<Person> PeopleWithAustralianShepherd = context.People
             .Include(p => p.Pets)
             .Where(person => person.Pets.Where(pet => pet.Breed.Contains("Australian")).Any(pet => pet.Name.Equals("Naïa")));
        DisplayElements(PeopleWithAustralianShepherd.ToList());

        return PeopleWithAustralianShepherd.ToList();
    }

    public static List<Person> GetPeopleUsingExpression(ApplicationContext context)
    {
        Console.WriteLine("Using Expression");

        Expression<Func<Person, bool>> HasAustralianShepherds = p => p.Pets.Any(pet => pet.Breed.Equals("Australian Shepherd") && pet.Name.Equals("Naïa"));
        var filteredResult = context.People.Where(HasAustralianShepherds);
        DisplayElements(filteredResult.ToList());

        return filteredResult.ToList();
    }

    static void DisplayElements<T>(List<T> list)
    {
        var elements = string.Empty;

        switch (typeof(T).Name)
        {
            case nameof(Int32):
                elements = string.Join(", ", list.Select(x => x!.ToString()));
                break;
            case nameof(Person):
                var people = list as List<Person>;
                elements = string.Join("\n", people!.Select(s => $"{s.LastName} {s.FirstName}"));
                break;
            default:
                break;
        }

        Console.WriteLine($"{elements}\n");
    }
}
