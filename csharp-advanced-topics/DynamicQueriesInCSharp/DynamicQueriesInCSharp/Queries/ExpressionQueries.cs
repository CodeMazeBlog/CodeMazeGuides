using DynamicQueriesInCSharp.Entities;
using DynamicQueriesInCSharp.Expressions;
using System.Linq.Expressions;

namespace DynamicQueriesInCSharp.Queries
{
    public static class ExpressionQueries
    {
        public static Expression<Func<Person, bool>> GetEqualExpression()
        {
            var expression = EqualExpression.CreateEqualExpression("FirstName", "Manoel");
            return expression;
        }

        public static Expression<Func<Person, bool>> GetEqualConjuctionExpression()
        {
            var filters = new Dictionary<string, object>();
            filters.Add("FirstName", "Manoel");
            filters.Add("LastName", "Nobrega");

            var expression = EqualExpression.CreateEqualExpression(filters);
            return expression;
        }

        public static Expression<Func<Person, bool>> GetContainsExpression()
        {
            var expression = ContainsExpression.CreateContainsExpression("FirstName", "Man");
            return expression;
        }

        public static Expression<Func<Person, bool>> GetInExpression()
        {
            var expression = ContainsExpression.CreateInExpression("Id", new int[] { 1, 2, 3 });
            return expression;
        }

        public static Expression<Func<Person, bool>> GetNestedExpression()
        {
            var expression = NestedExpression.CreateNestedExpression("Address.Country", "USA");
            return expression;
        }

        public static Expression<Func<Person, bool>> GetBetweenExpression()
        {
            var expression = CustomExpression.CreateBetweenExpression("Age", 18, 25);
            return expression;
        }

        public static Expression<Func<Person, bool>> GetHandleNullExpression()
        {
            var expression = HandleNullExpression.CreateEqualExpression("FirstName", "Manoel");
            return expression;
        }

        public static Expression<Func<Person, bool>> GetTypeCheckExpression()
        {
            var expression = TypeCheckExpression.CreateEqualExpression("FirstName", 1);
            return expression;
        }
    }
}
