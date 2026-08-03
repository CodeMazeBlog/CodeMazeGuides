using DynamicQueriesInCSharp.Entities;
using System.Linq.Expressions;

namespace DynamicQueriesInCSharp.Expressions
{
    public static class CustomExpression
    {
        public static Expression<Func<Person, bool>> CreateBetweenExpression(string propertyName, object lowerValue, object upperValue)
        {
            var param = Expression.Parameter(typeof(Person), "p");

            var member = Expression.Property(param, propertyName);

            var body = Expression.AndAlso(
                Expression.GreaterThanOrEqual(member, Expression.Constant(lowerValue)),
                Expression.LessThanOrEqual(member, Expression.Constant(upperValue))
            );

            return Expression.Lambda<Func<Person, bool>>(body, param);
        }
    }
}
