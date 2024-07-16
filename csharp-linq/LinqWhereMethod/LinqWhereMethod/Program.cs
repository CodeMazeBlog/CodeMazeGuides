using LinqWhereMethod;
using LinqWhereMethod.Models;

using var context = new ApplicationContext();
context.Database.EnsureCreated();

Helper.GetEvenNumbers();
Helper.GetOddNumbers();
Helper.GetPeopleWhoseNameStartsWithD(context);
Helper.GetPeopleBornFrom1974(context);
Helper.GetPeopleUsingChainingWhereOperators(context);
Helper.GetPeopleUsingNestedWhereOperators(context);
Helper.GetPeopleUsingExpression(context);


