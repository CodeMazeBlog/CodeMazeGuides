using DynamicQueriesInCSharp.Entities;
using System;
using System.Linq.Expressions;

namespace DynamicQueriesInCSharp.Expressions
{
    public static class HandleNullExpression
    {
        public static Expression<Func<Person, bool>> CreateEqualExpression(string propertyName, object value)
        {
            var param = Expression.Parameter(typeof(Person), "p");

            var member = Expression.Property(param, propertyName);

            var nullCheck = Expression.Equal(member, Expression.Constant(null));

            var constant = Expression.Constant(value);

            var body = Expression.Equal(member, constant);

            var condition = Expression.Condition(
                nullCheck,
                Expression.Constant(false),
                body
            );

            return Expression.Lambda<Func<Person, bool>>(condition, param);
        }

    }
}
