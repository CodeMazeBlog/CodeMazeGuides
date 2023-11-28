namespace ActionAndFuncDelegatesInCSharp.Test
{
    public class FuncUnitTest
    {
        [Fact]
        public void WhenAddNegativNumbers_ThenResultShouldBeInteger()
        {
            // Arrange
            Func<int, int, int> addFunc = Program.AddNumbers;

            // Act
            var addResult = Program.CalculateFunc(addFunc, -7, -5);

            // Assert
            Assert.IsType<int>(addResult);
        }

        [Fact]
        public void WhenAddNegativNumbers_ThenResultShouldCorrect()
        {
            // Arrange
            Func<int, int, int> addFunc = Program.AddNumbers;
            var expectedResult = -12;

            // Act
            var addResult = Program.CalculateFunc(addFunc, -7, -5);

            // Assert
            Assert.Equal(expectedResult, addResult);
        }

        [Fact]
        public void WhenAddNumbers_ThenResultShouldBeInteger()
        {
            // Arrange
            Func<int, int, int> addFunc = Program.AddNumbers;

            // Act
            var addResult = Program.CalculateFunc(addFunc, 7, 5);

            // Assert
            Assert.IsType<int>(addResult);
        }

        [Fact]
        public void WhenAddPositivNumbers_ThenResultShouldCorrect()
        {
            // Arrange
            Func<int, int, int> addFunc = Program.AddNumbers;
            var expectedResult = 12;

            // Act
            var addResult = Program.CalculateFunc(addFunc, 7, 5);

            // Assert
            Assert.Equal(expectedResult, addResult);
        }

        [Fact]
        public void WhenAddPostitivNumbers_ThenResultShouldBeInterger()
        {
            // Arrange
            Func<int, int, int> addFunc = Program.AddNumbers;

            // Act
            var addResult = Program.CalculateFunc(addFunc, 7, 5);

            // Assert
            Assert.IsType<int>(addResult);
        }

        [Fact]
        public void WhenSubtractNegativNumbers_ThenResultShouldBeCorrect()
        {
            // Arrange
            Func<int, int, int> subtractFunc = Program.SubtractNumbers;
            var expectedResult = -2;

            // Act
            var subtractResult = Program.CalculateFunc(subtractFunc, -7, -5);

            // Assert
            Assert.Equal(expectedResult, subtractResult);
        }

        [Fact]
        public void WhenSubtractPositivNumbers_ThenResultShouldBeCorrect()
        {
            // Arrange
            Func<int, int, int> subtractFunc = Program.SubtractNumbers;
            var expectedResult = 2;

            // Act
            var subtractResult = Program.CalculateFunc(subtractFunc, 7, 5);

            // Assert
            Assert.Equal(expectedResult, subtractResult);
        }

        [Fact]
        public void WhenSubtractPositivNumbers_ThenResultShouldBeInteger()
        {
            // Arrange
            Func<int, int, int> subtractFunc = Program.SubtractNumbers;

            // Act
            var subtractResult = Program.CalculateFunc(subtractFunc, 7, 5);

            // Assert
            Assert.IsType<int>(subtractResult);
        }
    }
}
