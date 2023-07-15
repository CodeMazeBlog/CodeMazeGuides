using ActionsAndFuncDelegatesInCsharp;

namespace Tests
{
    public class FuncTests
    {
        [Fact]
        public void WhenFuncIsSum_DelegateMethodNameMatchesReferenceMethodName()
        {
            var calculator = new Calculator();
            calculator.Function = Program.Sum;

            Assert.Equal(nameof(Program.Sum), calculator.Function.Method.Name);
        }

        [Fact]
        public void WhenFuncIsMultiply_DelegateMethodNameMatchesReferenceMethodName()
        {
            var calculator = new Calculator();
            calculator.Function = Program.Multiply;

            Assert.Equal(nameof(Program.Multiply), calculator.Function.Method.Name);
        }

        [Theory]
        [InlineData(2,3)]
        [InlineData(2,-10)]
        [InlineData(-5,3)]
        [InlineData(345345,3645456)]
        public void WhenFuncIsSum_DelegateSumsTheGivenIntegers(int firstNumber, int secondNumber)
        {
            var calculator = new Calculator();
            calculator.Function = Program.Sum;
            var result = calculator.GetResult(firstNumber, secondNumber);

            Assert.Equal(firstNumber + secondNumber, result);
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(2, -10)]
        [InlineData(-5, 3)]
        [InlineData(345345, 3645456)]
        public void WhenFuncIsMultiply_DelegateMultipliesTheGivenIntegers(int firstNumber, int secondNumber)
        {
            var calculator = new Calculator();
            calculator.Function = Program.Multiply;
            var result = calculator.GetResult(firstNumber, secondNumber);

            Assert.Equal(firstNumber * secondNumber, result);
        }

        [Theory]
        [InlineData(2, 3)]
        public void WhenFuncIsNotSet_ThrowsException(int firstNumber, int secondNumber)
        {
            var calculator = new Calculator();
            try
            {
                var result = calculator.GetResult(firstNumber, secondNumber);
                
                Assert.Fail("An exception should be thrown when func delegate is not set.");
            }
            catch (Exception ex)
            {
                Assert.Equal("Function not set!", ex.Message);
            }
        }
    }
}