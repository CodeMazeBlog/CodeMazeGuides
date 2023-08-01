using ActionsAndFuncDelegatesInCsharp;

namespace Tests
{
    public class ActionTests
    {
        [Fact]
        public void WhenActionIsDisplayBasic_ThenDelegateMethodNameMatchesReferenceMethodName()
        {
            var calculator = new Calculator();
            calculator.Action = Program.DisplayBasic;

            Assert.Equal(nameof(Program.DisplayBasic), calculator.Action.Method.Name);
        }

        [Fact]
        public void WhenActionIsDisplayVerbose_ThenDelegateMethodNameMatchesReferenceMethodName()
        {
            var calculator = new Calculator();
            calculator.Action = Program.DisplayVerbose;

            Assert.Equal(nameof(Program.DisplayVerbose), calculator.Action.Method.Name);
        }

        [Theory]
        [InlineData(2,3)]
        [InlineData(2,-10)]
        [InlineData(-5,3)]
        [InlineData(345345,3645456)]
        public void WhenActionIsDisplayBasicAndFuncIsSet_ThenDelegateExecutesActionWithoutError(int firstNumber, int secondNumber)
        {
            var calculator = new Calculator();
            calculator.Function = Program.Sum;
            calculator.Action = Program.DisplayBasic;
            calculator.DisplayResult(firstNumber, secondNumber);
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(2, -10)]
        [InlineData(-5, 3)]
        [InlineData(345345, 3645456)]
        public void WhenActionIsDisplayVerboseAndFuncIsSet_ThenDelegateExecutesActionWithoutError(int firstNumber, int secondNumber)
        {
            var calculator = new Calculator();
            calculator.Function = Program.Sum;
            calculator.Action = Program.DisplayVerbose;
            calculator.DisplayResult(firstNumber, secondNumber);
        }

        [Theory]
        [InlineData(2, 3)]
        public void WhenActiobIsNotSet_ThenThrowsException(int firstNumber, int secondNumber)
        {
            var calculator = new Calculator();
            calculator.Function = Program.Sum;
            try
            {
                calculator.DisplayResult(firstNumber, secondNumber);
                
                Assert.Fail("An exception should be thrown when func delegate is not set.");
            }
            catch (Exception ex)
            {
                Assert.Equal("Action not set!", ex.Message);
            }
        }
    }
}