using System.Reflection;

namespace ActionAndFuncDelegatesInCSharp.Test
{
    public class FuncUnitTest
    {
        [Fact]
        public void WhenCalculateNumber_ThenResultShouldBeInteger()
        {
            // Arrange
            Func<int, int, int> addFunc = Program.AddNumbers;

            // Act
            var addResult = Program.CalculateFunc(addFunc, 7, 5);

            // Assert
            Assert.IsType<int>(addResult);
        }

        [Fact]
        public void WhenSubtactNumber_ThenResultShouldBeInteger()
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
