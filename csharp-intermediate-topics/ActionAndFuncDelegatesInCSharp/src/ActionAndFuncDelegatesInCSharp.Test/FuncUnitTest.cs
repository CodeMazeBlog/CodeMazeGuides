using System.Reflection;

namespace ActionAndFuncDelegatesInCSharp.Test
{
    public class FuncUnitTest
    {
        [Fact]
        public void WhenAddTwoNumber_ThenReturnCorrectValue()
        {
            // Arrange
            Func<int, int, int> addFunc = AddNumbers;

            // Act
            var addResult = CalculateFunc(addFunc, 7, 5);

            // Assert
            Assert.Equal(12, addResult);
        }

        [Fact]
        public void WhenSubtactTwoNumber_ThenReturnCorrectValue()
        {
            // Arrange
            Func<int, int, int> subtractFunc = SubtractNumbers;

            // Act
            var subtractResult = CalculateFunc(subtractFunc, 7, 5);

            // Assert
            Assert.Equal(2, subtractResult);
        }

        private static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        private static TResult CalculateFunc<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 arg1, T2 arg2)
        {
            return func(arg1, arg2);
        }

        private static int SubtractNumbers(int a, int b)
        {
            return a - b;
        }
    }
}
