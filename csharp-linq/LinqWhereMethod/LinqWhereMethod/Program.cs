using LinqWhereMethod.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using var context = new ApplicationContext();
context.Database.EnsureCreated();

GetEvenNumbers();
GetOddNumbers();
GetPeopleWhoseNameStartsWithD(context);
GetPeopleBornFrom1974(context);
GetPeopleUsingChainingWhereOperators(context);
GetPeopleUsingImbricatedWhereOperators(context);
GetPeopleUsingExpression(context);

static IEnumerable<int> GetEvenNumbers()
{
    Console.WriteLine("Get even numbers");
    var randomNumbers = new int[] { 1, 5, 23, 11, 7, 2, 9, 8, 3, 6, 4, 20, 15, 0, 18, 13, 10, 33 };
    var evenNumbers = randomNumbers.OrderBy(x => x).Where(x => x % 2 == 0);
    DisplayElements(evenNumbers);

    return evenNumbers;
}

static IEnumerable<int> GetOddNumbers()
{
    Console.WriteLine("Get odd numbers");
    var sequenceOfNumbers = Enumerable.Range(50, 10).ToList();
    var oddNumbers = sequenceOfNumbers.Where((n, index) => index % 2 != 0);
    DisplayElements(oddNumbers);

    return oddNumbers;
}

static IEnumerable<Person> GetPeopleWhoseNameStartsWithD(ApplicationContext context)
{
    Console.WriteLine("Get people whose firstname starts with 'D'");
    //Enumerable.Where method
    IEnumerable<Person> people = context.People.ToList();
    var filteredPeople = people.Where(p => p.FirstName.ToUpper().StartsWith("D"));
    DisplayElements(filteredPeople);

    return filteredPeople;
}

static IEnumerable<Person> GetPeopleBornFrom1974(ApplicationContext context)
{
    Console.WriteLine("Get people born from 1974");
    //Queryable.Where method
    IQueryable<Person> queryResult = context.People.Where(p => p.BirthDate.Year >= 1974);
    DisplayElements(queryResult.ToList());

    return queryResult.ToList();
}

static IEnumerable<Person> GetPeopleUsingChainingWhereOperators(ApplicationContext context)
{
    Console.WriteLine("Chaining Where operators");
    //Chaining Where methods
    IQueryable <Person> result = context.People
        .Include(person => person.Address)
        .Where(s => s.BirthDate.Year < 1974).Where(s => s.Address.City.Equals("NANCY"));
    DisplayElements(result.ToList());

    return result.ToList();
}

static IEnumerable<Person> GetPeopleUsingImbricatedWhereOperators(ApplicationContext context)
{
    Console.WriteLine("Imbricated Where operators");
    //Imbricated Where operators
    IQueryable<Person> PeopleWithAustralianShepherd = context.People
         .Include(p => p.Pets)
         .Where(person => person.Pets.Where(pet => pet.Breed.Equals("Australian Shepherd")).Any());
    DisplayElements(PeopleWithAustralianShepherd.ToList());

    return PeopleWithAustralianShepherd.ToList();
}

static IEnumerable<Person> GetPeopleUsingExpression(ApplicationContext context)
{
    Console.WriteLine("Using Expression");
    //With an Expression as Where parameter
    Expression<Func<Person, bool>> HasAustralianShepherds = p => p.Pets.Any(pet => pet.Breed.Equals("Australian Shepherd"));
    var filteredResult = context.People.Where(HasAustralianShepherds);
    DisplayElements(filteredResult.ToList());

    return filteredResult.ToList();
}

static void DisplayElements<T> (IEnumerable<T> list)
{
    var elements = string.Empty;
  
    switch (typeof(T).Name)
    {
        case nameof(Int32):
            elements = string.Join(", ", ((IEnumerable<int>)list).Select(x => x.ToString()));
            break;
        case nameof(Person):
            elements = string.Join("\n", ((IEnumerable<Person>)list).Select(s => $"{s.LastName} {s.FirstName}"));
            break;
        default:
            break;
    }

    Console.WriteLine($"{elements}\n");
}

//Used in testing project
public partial class Program { }

