using DynamicQueriesInCSharp.Entities;
using System.Linq.Expressions;

namespace DynamicQueriesInCSharp.Expressions
{
    public static class TypeCheckExpression
    {
        public static Expression<Func<Person, bool>> CreateEqualExpression(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(Person), "p");

            var member = Expression.Property(param, propertyName);

            var typeCheck = Expression.TypeEqual(Expression.Constant(value), typeof(string));

            var constant = Expression.Constant(value, typeof(object));

            var condition = Expression.Condition(
                typeCheck,
                Expression.Equal(member, constant),
                Expression.Constant(false)
            );

            return Expression.Lambda<Func<Person, bool>>(condition, param);
        }
    }
}
