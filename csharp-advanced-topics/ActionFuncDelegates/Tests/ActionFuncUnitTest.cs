using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ActionFuncUnitTest
    {

        public delegate int ReturnDelegate(int input);

        [Fact]
        public void WhenGetsNumber_ThenReturnsItsSquare()
        {
            int expected = 16;
            ReturnDelegate ReturnValueDelegate = (input) => input * input;
            int actual = ReturnValueDelegate(4);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void WhenGetsTwoNumbers_ThenReturnsTheirSum()
        {
            int expected = 30;
            Func<int, int, int> FuncReturnSumOfTwoNumbers = (a, b) => (a + b);
            int actual = FuncReturnSumOfTwoNumbers(10, 20);
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void WhenGetsTwoNumbers_ThenMultipliesThem()
        {
            int expected = 100;
            Func<int, int, int> multiply = (a, b) => a * b;
            int actual = multiply(20, 5);
            Assert.Equal(actual, expected);
        }
    }
}
