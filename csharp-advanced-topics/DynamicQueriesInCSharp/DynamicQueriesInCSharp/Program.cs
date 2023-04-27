using DynamicQueriesInCSharp.Context;
using DynamicQueriesInCSharp.Entities;
using DynamicQueriesInCSharp.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DynamicQueriesInCSharp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var context = CreateDbContext();

            DbSet<Person> persons = context.Persons;

            var query = GetExpressionTree(persons);
            Console.WriteLine(query);

            query = GetEqualExpression(persons);
            Console.WriteLine(query);

            query = GetEqualExpressionConjuction(persons);
            Console.WriteLine(query);

            query = GetContainsExpression(persons);
            Console.WriteLine(query);

            query = GetInExpression(persons);
            Console.WriteLine(query);

            query = GetNestedExpression(persons);
            Console.WriteLine(query);

            query = GetBetweenExpression(persons);
            Console.WriteLine(query);
        }

        public static ApplicationDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=test;Integrated Security=True")
                .Options;

            var context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            return context;
        }

        public static string GetExpressionTree(DbSet<Person> persons)
        {
            var query = persons.Where(p => p.FirstName == "Manoel");

            return query.ToQueryString();
        }

        public static string GetEqualExpression(DbSet<Person> persons)
        {
            var expression = EqualExpression.CreateEqualExpression("FirstName", "Manoel");
            return persons.Where(expression).ToQueryString();
        }

        public static string GetEqualExpressionConjuction(DbSet<Person> persons)
        {
            var filters = new Dictionary<string, object>();
            filters.Add("FirstName", "Manoel");
            filters.Add("LastName", "Nobrega");

            var expression = EqualExpression.CreateEqualExpression(filters);
            return persons.Where(expression).ToQueryString();
        }

        public static string GetContainsExpression(DbSet<Person> persons)
        {
            var expression = ContainsExpression.CreateContainsExpression("FirstName", "Man");
            return persons.Where(expression).ToQueryString();
        }

        public static string GetInExpression(DbSet<Person> persons)
        {
            var expression = ContainsExpression.CreateInExpression("Id", new int[] { 1, 2, 3 });
            return persons.Where(expression).ToQueryString();
        }

        public static string GetNestedExpression(DbSet<Person> persons)
        {
            var expression = NestedExpression.CreateNestedExpression("Address.Country", "USA");
            return persons.Where(expression).ToQueryString();
        }

        public static string GetBetweenExpression(DbSet<Person> persons)
        {
            var expression = CustomExpression.CreateBetweenExpression("Age", 18, 25);
            return persons.Where(expression).ToQueryString();
        }
    }
}