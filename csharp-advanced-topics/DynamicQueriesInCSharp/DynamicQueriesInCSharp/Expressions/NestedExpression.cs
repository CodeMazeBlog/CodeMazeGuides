using DynamicQueriesInCSharp.Entities;
using System.Linq.Expressions;

namespace DynamicQueriesInCSharp.Expressions
{
    public static class NestedExpression
    {
        public static Expression<Func<Person, bool>> CreateNestedExpression(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(Person), "p");

            Expression member = param;

            foreach (var namePart in propertyName.Split('.'))
            {
                member = Expression.Property(member, namePart);
            }

            var constant = Expression.Constant(value);

            var body = Expression.Equal(member, constant);

            return Expression.Lambda<Func<Person, bool>>(body, param);
        }
    }
}
