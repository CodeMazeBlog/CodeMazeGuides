using ActionAndFuncDelegateInCSharp;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Tests
{
    public class ActionAndFuncDelegateInCSharpUnitTest
    {
        [Theory]
        [InlineData(10000)]
        [InlineData(110000)]
        [InlineData(1110000)]
        public void GivenFuncDelegate_WhenWritingFuncDelegate_ThenReturnNumberWithFormat(int input)
        {
            Func<int, string> formula = x => string.Format("{0:n0}", x);
            var resultFunc = FuncDelegates.PrintNumbersByFormula(formula, input);
            Assert.Equal(resultFunc, formula(input));
        }

        [Theory]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(300)]
        public void GivenActionDelegate_WhenWritingActionDelegate_ThenReturnMessage(int input)
        {
            ActionDelegates.WriteMessage(x => Console.WriteLine(ActionDelegates.Message), input);
            Assert.Equal(ActionDelegates.Message, $"Number: {input}");
        }
    }
}