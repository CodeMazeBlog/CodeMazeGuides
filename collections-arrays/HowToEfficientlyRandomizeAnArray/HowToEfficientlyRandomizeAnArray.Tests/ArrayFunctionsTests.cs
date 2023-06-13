using FluentAssertions;

namespace HowToEfficientlyRandomizeAnArray.Tests
{
    public class ArrayFunctionsTests
    {
        private readonly int[] _array;
        private const int ARRAY_SIZE = 1000;
        private readonly ArrayFunctions _arrayFunctions;

        public ArrayFunctionsTests()
        {
            _arrayFunctions = new ArrayFunctions();
            _array = _arrayFunctions.GerOrderedArray(ARRAY_SIZE);
        }

        [Fact]
        public void WhenGerOrderedArrayIsInvoked_ThenOrderedArrayIsReturned()
        {
            // Act
            var array = _arrayFunctions.GerOrderedArray(ARRAY_SIZE);

            // Assert
            array.Should().NotBeNullOrEmpty();
            array.Should().BeInAscendingOrder();
        }

        [Fact]
        public void WhenRandomizeWithOrderByAndGuidIsInvoked_ThenArrayIsRandomized()
        {
            // Act
            var randomizedArray = _arrayFunctions.RandomizeWithOrderByAndGuid(_array);

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
            var randomizedArray = _arrayFunctions.RandomizeWithOrderByAndRandom(_array);

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
            var randomizedArray = _arrayFunctions.RandomizeWithFisherYates(_array);

            // Assert
            randomizedArray
                .Should().NotBeNullOrEmpty()
                .And.NotBeInAscendingOrder()
                .And.NotBeInDescendingOrder();
        }
    }
}