namespace ActionAndFuncDelegatesTests
{
    public class Tests
    {
        [Fact]
        public void GivenListWithNumbers_WhenFilteringWithEnumerableWhere_ThenFilteredEvenNumbers()
        {
            // Arrange
            var listWithNumbers = new List<int> { 1, 4, 3, 6, 9, 2 };

            // Act
            var listWithEvenNumbers = listWithNumbers.Where(number => number % 2 == 0);

            // Assert
            Assert.True(listWithEvenNumbers.Count() == 3);
            Assert.Equal(listWithEvenNumbers, new List<int>{ 4, 6, 2});
        }

        [Fact]
        public void WhenFuncDelegate_ThenAddedNumbers()
        {
            // Arrange
            Func<int, int, int> addFuncWithLambda = (first, second) => first + second;

            // Act
            var result = addFuncWithLambda(3, 5);

            // Assert
            Assert.Equal(8, result);
        }
    }
}