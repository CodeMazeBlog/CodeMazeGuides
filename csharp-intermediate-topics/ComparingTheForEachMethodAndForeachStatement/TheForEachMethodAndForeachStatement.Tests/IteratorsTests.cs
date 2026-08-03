namespace TheForEachMethodAndForeachStatement.Tests
{
    public class IteratorsTests
    {
        [Theory, ClassData(typeof(ListOfIntTestData))]
        public void WhenGetTotalOfIntListWithForEachMethodIsInvoked_ThenValidResultIsReturned(List<int> prices, int expected)
        {
            // Act
            var result = Iterators.GetTotalOfIntListWithForEachMethod(prices);

            // Assert
            result.Should().Be(expected);
        }

        [Theory, ClassData(typeof(ListOfIntTestData))]
        public void WhenGetTotalOfIntListWithForeachStatementIsInvoked_ThenValidResultIsReturned(List<int> prices, int expected)
        {
            // Act
            var result = Iterators.GetTotalOfIntListWithForeachStatement(prices);

            // Assert
            result.Should().Be(expected);
        }

        [Theory, ClassData(typeof(ListOfProductsTestData))]
        public void WhenGetTotalOfProductsListWithForEachMethodIsInvoked_ThenValidResultIsReturned(List<Product> products, int expected)
        {
            // Act
            var result = Iterators.GetTotalOfProductsListWithForEachMethod(products);

            // Assert
            result.Should().Be(expected);
        }

        [Theory, ClassData(typeof(ListOfProductsTestData))]
        public void WhenGetTotalOfProductsListWithForeachStatementIsInvoked_ThenValidResultIsReturned(List<Product> products, int expected)
        {
            // Act
            var result = Iterators.GetTotalOfProductsListWithForeachStatement(products);

            // Assert
            result.Should().Be(expected);
        }
    }
}