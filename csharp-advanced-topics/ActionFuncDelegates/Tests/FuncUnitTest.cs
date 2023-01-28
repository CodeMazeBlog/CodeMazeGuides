using ActionFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FuncUnitTest
    {
        [Fact]
        public void WhenGetsTwoNumbers_ThenReturnsTheirSum()
        {
            FuncDelegate funcDelegate = new FuncDelegate();

            int expected = 30;
            int actual = funcDelegate.Sum(10, 20);

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void WhenGetsTwoNumbers_ThenMultipliesThem()
        {
            FuncDelegate funcDelegate = new FuncDelegate();

            int expected = 100;
            int actual = funcDelegate.Multiply(20, 5);

            Assert.Equal(actual, expected);
        }
    }
}
