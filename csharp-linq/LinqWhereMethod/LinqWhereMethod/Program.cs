using LinqWhereMethod;
using LinqWhereMethod.Models;

using var context = new ApplicationContext();
context.Database.EnsureCreated();

        Console.WriteLine("Get even numbers");
var evenNumbers = Helper.GetEvenNumbers();
DisplayElements(evenNumbers);

Helper.GetOddNumbers();
Helper.GetPeopleWhoseNameStartsWithD(context);
Helper.GetPeopleBornFrom1974(context);
Helper.GetPeopleUsingChainingWhereOperators(context);
Helper.GetPeopleUsingNestedWhereOperators(context);
Helper.GetPeopleUsingExpression(context);

return;

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
