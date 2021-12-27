using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionVsFuncDelegates.Tests
{
    public class MathFuncTest
    {
        [Theory]
        [InlineData(3, 2, 5)]
        [InlineData(9, 2, 11)]
        [InlineData(5, 2, 7)]
        public void sum_method_test(int a, int b, int result)
        {
            var mathFunc = new MathFunc();
            Assert.Equal(result, mathFunc.GetSum(a, b));
        }

        [Theory]
        [InlineData(9, 2, 7)]
        [InlineData(6, 1, 5)]
        [InlineData(22, 3, 19)]
        public void minus_method_test(int a, int b, int result)
        {
            var mathFunc = new MathFunc();
            Assert.Equal(result, mathFunc.GetMinus(a, b));
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(6, 1, 6)]
        [InlineData(3, 4, 12)]
        public void multiplied_method_test(int a, int b, int result)
        {
            var mathFunc = new MathFunc();
            Assert.Equal(result, mathFunc.GetMultiplied(a, b));
        }
    }
}
