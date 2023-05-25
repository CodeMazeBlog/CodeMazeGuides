using DynamicQueriesInCSharp.Context;
using DynamicQueriesInCSharp.Entities;
using DynamicQueriesInCSharp.Helper;
using DynamicQueriesInCSharp.Queries;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    [TestClass]
    public class DynamicQueriesInCSharpLiveTest
    {
        private readonly DbSet<Person> _persons;

        public DynamicQueriesInCSharpLiveTest()
        {
            var context = new ContextFactory().CreateDbContext();

            _persons = context.Persons;
        }

        [TestMethod]
        public void WhenCreateEqualExpresisonTree_ThenReturnGeneratedQuery()
        {
            var expression = ExpressionQueries.GetEqualExpression();
            var json = QueryableHelper.Create(_persons, expression).ToQueryString();

            var expectedResult = $"SELECT [p].[Id], [p].[Age], [p].[FirstName], [p].[LastName], [p].[Address_AddressLine], [p].[Address_City], [p].[Address_Country], [p].[Address_State]{Environment.NewLine}FROM [Persons] AS [p]{Environment.NewLine}WHERE [p].[FirstName] = N'Manoel'";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenCreateEqualExpresisonConjuctionTree_ThenReturnGeneratedQuery()
        {
            var expression = ExpressionQueries.GetEqualConjuctionExpression();
            var json = QueryableHelper.Create(_persons, expression).ToQueryString();

            var expectedResult = $"SELECT [p].[Id], [p].[Age], [p].[FirstName], [p].[LastName], [p].[Address_AddressLine], [p].[Address_City], [p].[Address_Country], [p].[Address_State]{Environment.NewLine}FROM [Persons] AS [p]{Environment.NewLine}WHERE [p].[FirstName] = N'Manoel' AND [p].[LastName] = N'Nobrega'";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenCreateContainsExpressionTree_ThenReturnGeneratedQuery()
        {
            var expression = ExpressionQueries.GetContainsExpression();
            var json = QueryableHelper.Create(_persons, expression).ToQueryString();

            var expectedResult = $"SELECT [p].[Id], [p].[Age], [p].[FirstName], [p].[LastName], [p].[Address_AddressLine], [p].[Address_City], [p].[Address_Country], [p].[Address_State]{Environment.NewLine}FROM [Persons] AS [p]{Environment.NewLine}WHERE [p].[FirstName] LIKE N'%Man%'";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenCreateInExpressionTree_ThenReturnGeneratedQuery()
        {
            var expression = ExpressionQueries.GetInExpression();
            var json = QueryableHelper.Create(_persons, expression).ToQueryString();

            var expectedResult = $"SELECT [p].[Id], [p].[Age], [p].[FirstName], [p].[LastName], [p].[Address_AddressLine], [p].[Address_City], [p].[Address_Country], [p].[Address_State]{Environment.NewLine}FROM [Persons] AS [p]{Environment.NewLine}WHERE [p].[Id] IN (1, 2, 3)";

            Assert.AreEqual(expectedResult, json);
        }


        [TestMethod]
        public void WhenCreateNestedExpressionTree_ThenReturnGeneratedQuery()
        {
            var expression = ExpressionQueries.GetNestedExpression();
            var json = QueryableHelper.Create(_persons, expression).ToQueryString();

            var expectedResult = $"SELECT [p].[Id], [p].[Age], [p].[FirstName], [p].[LastName], [p].[Address_AddressLine], [p].[Address_City], [p].[Address_Country], [p].[Address_State]{Environment.NewLine}FROM [Persons] AS [p]{Environment.NewLine}WHERE [p].[Address_Country] = N'USA'";

            Assert.AreEqual(expectedResult, json);
        }

        [TestMethod]
        public void WhenCreateBetweenExpressionTree_ThenReturnGeneratedQuery()
        {
            var expression = ExpressionQueries.GetBetweenExpression();
            var json = QueryableHelper.Create(_persons, expression).ToQueryString();

            var expectedResult = $"SELECT [p].[Id], [p].[Age], [p].[FirstName], [p].[LastName], [p].[Address_AddressLine], [p].[Address_City], [p].[Address_Country], [p].[Address_State]{Environment.NewLine}FROM [Persons] AS [p]{Environment.NewLine}WHERE [p].[Age] >= 18 AND [p].[Age] <= 25";

            Assert.AreEqual(expectedResult, json);
        }
    }
}