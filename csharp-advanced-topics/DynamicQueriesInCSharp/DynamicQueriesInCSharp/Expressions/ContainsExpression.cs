using DynamicQueriesInCSharp.Entities;
using System.Linq.Expressions;
using System.Reflection;

namespace DynamicQueriesInCSharp.Expressions
{
    public static class ContainsExpression
    {
        public static Expression<Func<Person, bool>> CreateContainsExpression(string propertyName, string value)
        {
            var param = Expression.Parameter(typeof(Person), "p");

            var member = Expression.Property(param, propertyName);

            var constant = Expression.Constant(value);

            var body = Expression.Call(member, "Contains", Type.EmptyTypes, constant);

            return Expression.Lambda<Func<Person, bool>>(body, param);
        }

        public static Expression<Func<Person, bool>> CreateInExpression(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(Person), "p");

            var member = Expression.Property(param, propertyName);

            var propertyType = ((PropertyInfo)member.Member).PropertyType;

            var constant = Expression.Constant(value);

            var body = Expression.Call(typeof(Enumerable), "Contains", new[] { propertyType }, constant, member);

            return Expression.Lambda<Func<Person, bool>>(body, param);
        }
    }
}
