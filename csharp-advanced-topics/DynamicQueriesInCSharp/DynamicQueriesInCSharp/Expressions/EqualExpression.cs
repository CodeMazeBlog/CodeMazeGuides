using DynamicQueriesInCSharp.Entities;
using System.Linq.Expressions;

namespace DynamicQueriesInCSharp.Expressions
{
    public static class EqualExpression
    {
        public static Expression<Func<Person, bool>> CreateEqualExpression(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(Person), "p");

            var member = Expression.Property(param, propertyName);

            var constant = Expression.Constant(value);

            var body = Expression.Equal(member, constant);

            return Expression.Lambda<Func<Person, bool>>(body, param);
        }

        public static Expression<Func<Person, bool>> CreateEqualExpression(IDictionary<string, object> filters)
        {
            var param = Expression.Parameter(typeof(Person), "p");

            Expression? body = null;

            foreach (var pair in filters)
            {
                var member = Expression.Property(param, pair.Key);

                var constant = Expression.Constant(pair.Value);

                var expression = Expression.Equal(member, constant);

                body = body == null ? expression : Expression.AndAlso(body, expression);
            }

            return Expression.Lambda<Func<Person, bool>>(body, param);
        }
    }
}
