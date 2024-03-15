using DynamicQueriesInCSharp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DynamicQueriesInCSharp.Helper
{
    public static class QueryableHelper
    {
        public static IQueryable<Person> Create(DbSet<Person> persons, Expression<Func<Person, bool>> expression)
        {
            return persons.Where(expression);
        }

        public static IEnumerable<Person> Create(DbSet<Person> persons, Func<Person, bool> expression)
        {
            return persons.Where(expression);
        }
    }
}
