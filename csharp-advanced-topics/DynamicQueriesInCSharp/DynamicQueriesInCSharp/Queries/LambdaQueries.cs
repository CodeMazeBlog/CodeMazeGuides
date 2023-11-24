using DynamicQueriesInCSharp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DynamicQueriesInCSharp.Queries
{
    public static class LambdaQueries
    {
        public static Expression<Func<Person, bool>> GetEqualExpression()
        {
            return p => p.FirstName == "Manoel";
        }

        public static Expression<Func<Person, bool>> GetEqualConjuctionExpression()
        {
            return p => p.FirstName == "Manoel" && p.LastName == "Nobrega";
        }

        public static Expression<Func<Person, bool>> GetContainsExpression()
        {
            return p => p.FirstName.Contains("Man");
        }

        public static Expression<Func<Person, bool>> GetInExpression()
        {
            var constant = new int[] { 1, 2, 3 };

            return p => constant.Contains(p.Id);
        }

        public static Expression<Func<Person, bool>> GetNestedExpression()
        {
            return p => p.Address.Country == "USA";
        }

        public static Expression<Func<Person, bool>> GetBetweenExpression()
        {
            return p => p.Age >= 18 && p.Age <= 25;
        }
    }
}
