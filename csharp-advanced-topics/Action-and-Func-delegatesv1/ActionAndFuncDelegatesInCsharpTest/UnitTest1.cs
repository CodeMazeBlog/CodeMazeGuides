using System;
using Xunit;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace ActionAndFuncDelegatesInCsharpTest
{
    public class ActionFunPredicateUnitTest
    {
        private ITestOutputHelper _outputHelper { get; }
        private readonly Func<string> func = () => "Hello ....";
        private readonly Func<string, string> func2 = (string name) => $"Hello {name} ";
        private readonly Func<string, int, int, string> func3 = (string name, int firstNumber, int secondNumber) => $"Hello,  {name}  says {firstNumber} x {secondNumber} = {firstNumber * secondNumber}";
        
        public ActionFunPredicateUnitTest(ITestOutputHelper outputHelper)
        {

            _outputHelper = outputHelper;
        }

        [Fact]
        public void Given_FUNC_When_WithNoParameter_Then_ReturnNonNullValue()
        {
            _outputHelper.WriteLine($"No Parameter passed for func() with expected Output as {func()}");
            Assert.NotNull(func());
        }

        [InlineData("Isaac Mwirigi Njiru", 5, 5)]
        [InlineData("Isaac Mwirigi Njiru", 5, 6)]
        [InlineData("Isaac Mwirigi Njiru", 7, 6)]
        [Theory]
        public void Given_FUNC_When_WithParameter_Then_ReturnNonNullValue(string name, int firstNumber, int secondNumber)
        {
            
            _outputHelper.WriteLine($"Parameter passed for func({name}) with expected Output as {func2(name)}");
            Assert.NotNull(func2(name));
            _outputHelper.WriteLine($"Parameter passed for func({name}, {firstNumber}, {secondNumber}) with expected Output as {func3(name, firstNumber, secondNumber)}");
            Assert.NotNull(func3(name, firstNumber, secondNumber));
            


        }

        [InlineData("Isaac Mwirigi Njiru", 5, 5)]
        [InlineData("Isaac Mwirigi Njiru", 5, 6)]
        [InlineData("Isaac Mwirigi Njiru", 7, 6)]
        [Theory]
        public void Given_ACTION_When_WithParameter_Then_ReturnVoid(string name, int firstNumber, int secondNumber)
        {
            // Action<string> _action = () => _outputHelper.WriteLine($"Hello {name} "); Cannot accept no paramter

            Action<string> action = (string name) => _outputHelper.WriteLine($"Action delegate called with Parameter {name} return void ");
            action(name);
            Action<string, int, int> action2 = (string name, int firstNumber, int secondNumber) => _outputHelper.WriteLine($"Parameter passed for Action({name}, {firstNumber}, {secondNumber}) with expected Void");
            action2(name, firstNumber, secondNumber);
        }

        
    }
}
