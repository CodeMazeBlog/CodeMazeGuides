using DynamicQueriesInCSharp.Entities;
using System.Linq.Expressions;

namespace DynamicQueriesInCSharp.Expressions
{
    public static class DocumentExpression
    {
        /// <summary>
        /// Constructs an expression tree representing an equality comparison between property and value.
        /// </summary>
        /// <param name="propertyName">The property of the object.</param>
        /// <param name="value">>The value to compare.</param>
        /// <returns>An expression tree representing the equality comparison.</returns>
        public static Expression<Func<Person, bool>> CreateEqualExpression(string propertyName, object value)
        {
            // Create the parameter expression: p
            var param = Expression.Parameter(typeof(Person), "p");

            // Create the property expression: p."param"
            var member = Expression.Property(param, propertyName);

            // Create the constant expression: value
            var constant = Expression.Constant(value);

            // Create the binary expression: p."param" == value
            var body = Expression.Equal(member, constant);

            // Create the expression lambda p => p."param" == value
            return Expression.Lambda<Func<Person, bool>>(body, param);
        }
    }
}
