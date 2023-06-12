using FluentAssertions;

namespace HowToEfficientlyRandomizeAnArray.Tests
{
    public class ArrayFunctionsTests
    {
        private const int ARRAY_SIZE = 100;

        [Fact]
        public void WhenGerOrderedArrayIsInvoked_ThenOrderedArrayIsReturned()
        {
            // Act
            var array = ArrayFunctions.GerOrderedArray(ARRAY_SIZE);

            // Assert
            array.Should().NotBeNullOrEmpty();
            array.Should().BeInAscendingOrder();
        }

        [Fact]
        public void WhenRandomizeWithOrderByAndGuidIsInvoked_ThenArrayIsRandomized()
        {
            // Arrange
            var array = ArrayFunctions.GerOrderedArray(ARRAY_SIZE);

            // Act
            var randomizedArray = ArrayFunctions.RandomizeWithOrderByAndGuid(array);

            // Assert
            randomizedArray.Should().NotBeNullOrEmpty();
            randomizedArray.Should().NotBeInAscendingOrder();
            randomizedArray.Should().NotBeInDescendingOrder();
        }

        [Fact]
        public void WhenRandomizeWithOrderByAndRandomIsInvoked_ThenArrayIsRandomized()
        {
            // Arrange
            var array = ArrayFunctions.GerOrderedArray(ARRAY_SIZE);

            // Act
            var randomizedArray = ArrayFunctions.RandomizeWithOrderByAndRandom(array);

            // Assert
            randomizedArray.Should().NotBeNullOrEmpty();
            randomizedArray.Should().NotBeInAscendingOrder();
            randomizedArray.Should().NotBeInDescendingOrder();
        }

        [Fact]
        public void WhenRandomizeWithFisherYatesIsInvoked_ThenArrayIsRandomized()
        {
            // Arrange
            var array = ArrayFunctions.GerOrderedArray(ARRAY_SIZE);

            // Act
            var randomizedArray = ArrayFunctions.RandomizeWithFisherYates(array);

            // Assert
            randomizedArray.Should().NotBeNullOrEmpty();
            randomizedArray.Should().NotBeInAscendingOrder();
            randomizedArray.Should().NotBeInDescendingOrder();
        }
    }
}