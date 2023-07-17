using FluentAssertions;

namespace HowToEfficientlyRandomizeAnArray.Tests
{
    public class ArrayFunctionsTests
    {
        private readonly int[] _array;
        private const int ARRAY_SIZE = 1000;

        public ArrayFunctionsTests()
        {
            _array = ArrayFunctions.GetOrderedArray(ARRAY_SIZE);
        }

        [Fact]
        public void WhenGetOrderedArrayIsInvoked_ThenOrderedArrayIsReturned()
        {
            // Act
            var array = ArrayFunctions.GetOrderedArray(ARRAY_SIZE);

            // Assert
            array.Should().NotBeNullOrEmpty();
            array.Should().BeInAscendingOrder();
        }

        [Fact]
        public void WhenRandomizeWithOrderByAndGuidIsInvoked_ThenArrayIsRandomized()
        {
            // Act
            var randomizedArray = ArrayFunctions.RandomizeWithOrderByAndGuid(_array);

            // Assert
            randomizedArray
                .Should().NotBeNullOrEmpty()
                .And.NotBeInAscendingOrder()
                .And.NotBeInDescendingOrder();
        }

        [Fact]
        public void WhenRandomizeWithOrderByAndRandomIsInvoked_ThenArrayIsRandomized()
        {
            // Act
            var randomizedArray = ArrayFunctions.RandomizeWithOrderByAndRandom(_array);

            // Assert
            randomizedArray
                .Should().NotBeNullOrEmpty()
                .And.NotBeInAscendingOrder()
                .And.NotBeInDescendingOrder();
        }

        [Fact]
        public void WhenRandomizeWithFisherYatesIsInvoked_ThenArrayIsRandomized()
        {
            // Act
            var randomizedArray = ArrayFunctions.RandomizeWithFisherYates(_array);

            // Assert
            randomizedArray
                .Should().NotBeNullOrEmpty()
                .And.NotBeInAscendingOrder()
                .And.NotBeInDescendingOrder();
        }

        [Fact]
        public void WhenRandomizeWithFisherYatesCopiedArrayIsInvoked_ThenArrayIsRandomized()
        {
            // Act
            var randomizedArray = ArrayFunctions.RandomizeWithFisherYatesCopiedArray(_array);

            // Assert
            randomizedArray
                .Should().NotBeNullOrEmpty()
                .And.NotBeInAscendingOrder()
                .And.NotBeInDescendingOrder();
        }
    }
}