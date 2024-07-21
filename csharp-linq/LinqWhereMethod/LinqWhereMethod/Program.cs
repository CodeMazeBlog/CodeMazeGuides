using LinqWhereMethod;
using LinqWhereMethod.Models;

using var context = new ApplicationContext();
context.Database.EnsureCreated();

Console.WriteLine("Get even numbers");
var evenNumbers = Helper.GetEvenNumbers();
DisplayElements(evenNumbers);

Console.WriteLine("Get odd numbers");
var oddNumbers = Helper.GetOddNumbers();
DisplayElements(oddNumbers);

Console.WriteLine("Get people whose firstname starts with 'D'");
var filteredPeople = Helper.GetPeopleWhoseNameStartsWithD(context);
DisplayElements(filteredPeople);

Console.WriteLine("Get people born from 1974");
var peopleBornFrom1974 = Helper.GetPeopleBornFrom1974(context);
DisplayElements(peopleBornFrom1974);

Console.WriteLine("Chaining Where operators");
var peopleBornBefore1974LivingInNancy = Helper.GetPeopleUsingChainingWhereOperators(context);
DisplayElements(peopleBornBefore1974LivingInNancy);

Console.WriteLine("Nested Where operators");
var peopleWithAustralianShepherd = Helper.GetPeopleUsingNestedWhereOperators(context);
DisplayElements(peopleWithAustralianShepherd);

Console.WriteLine("Using Expression");
var peopleWithAustralianShepherdUsingExpression = Helper.GetPeopleUsingExpression(context);
DisplayElements(peopleWithAustralianShepherdUsingExpression);

void DisplayElements<T>(List<T> list)
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

