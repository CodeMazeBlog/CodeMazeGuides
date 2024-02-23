using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    public class FuncDelegatesTests
    {
        [Fact]
        public void GivenAFuncDelegate_WhenTwoIntegersAreProvided_ShouldReturnTheirSum()
        {
            // Arrange
            var x = 5;
            var y = 3;

            // Act
            var result = FuncDelegates.Add(x, y);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void GivenAFuncDelegate_WhenTwoIntegersAreProvided_ShouldReturnTheirDifference()
        {
            // Arrange
            var x = 7;
            var y = 4;

            // Act
            var result = FuncDelegates.Subtract(x, y);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void GivenAFuncDelegate_WhenTwoIntegersAreProvided_ShouldReturnTheirProduct()
        {
            // Arrange
            var x = 6;
            var y = 2;

            // Act
            var result = FuncDelegates.Multiply(x, y);

            // Assert
            Assert.Equal(12, result);
        }
    }
}
