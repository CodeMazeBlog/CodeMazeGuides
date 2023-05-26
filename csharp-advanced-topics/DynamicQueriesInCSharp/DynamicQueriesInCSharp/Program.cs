using DynamicQueriesInCSharp.Context;
using DynamicQueriesInCSharp.Entities;
using DynamicQueriesInCSharp.Helper;
using DynamicQueriesInCSharp.Queries;
using Microsoft.EntityFrameworkCore;

namespace DynamicQueriesInCSharp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var context = new ContextFactory().CreateDbContext();

            DbSet<Person> persons = context.Persons;

            // Example of expression

            var expression = LambdaQueries.GetEqualExpression();
            var query = QueryableHelper.Create(persons, expression).ToQueryString();
            Console.WriteLine(query);

            // Dynamic queries with expression

            expression = ExpressionQueries.GetEqualExpression();
            query = QueryableHelper.Create(persons, expression).ToQueryString();
            Console.WriteLine(query);

            expression = ExpressionQueries.GetEqualConjuctionExpression();
            query = QueryableHelper.Create(persons, expression).ToQueryString();
            Console.WriteLine(query);

            expression = ExpressionQueries.GetContainsExpression();
            query = QueryableHelper.Create(persons, expression).ToQueryString();
            Console.WriteLine(query);

            expression = ExpressionQueries.GetInExpression();
            query = QueryableHelper.Create(persons, expression).ToQueryString();
            Console.WriteLine(query);

            expression = ExpressionQueries.GetNestedExpression();
            query = QueryableHelper.Create(persons, expression).ToQueryString();
            Console.WriteLine(query);

            expression = ExpressionQueries.GetHandleNullExpression();
            query = QueryableHelper.Create(persons, expression).ToQueryString();
            Console.WriteLine(query);

            // Compiled expression

            expression = ExpressionQueries.GetEqualExpression();
            var predicate = ExpressionCacheHelper.GetPredicate(expression);
            var enumerable = QueryableHelper.Create(persons, predicate);
            Console.WriteLine(enumerable);

            // Type check expression
            expression = ExpressionQueries.GetTypeCheckExpression();
            query = QueryableHelper.Create(persons, expression).ToQueryString();
            Console.WriteLine(query);
        }
    }
}