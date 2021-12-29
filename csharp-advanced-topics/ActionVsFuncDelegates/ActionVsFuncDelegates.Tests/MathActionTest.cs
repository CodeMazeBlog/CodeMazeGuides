using System;
using System.IO;
using Xunit;

namespace ActionVsFuncDelegates.Tests
{
    public class MathActionTest
    {
        [Theory]
        [InlineData(3, 2, 5)]
        [InlineData(9, 2, 11)]
        [InlineData(5, 2, 7)]
        public void sum_method_test(int a, int b, int result)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var mathAction = new MathAction();
            mathAction.ShowSum(a, b);

            Assert.Equal($"{a} + {b} = {result}\r\n", stringWriter.ToString());
        }

        [Theory]
        [InlineData(9, 2, 7)]
        [InlineData(6, 1, 5)]
        [InlineData(22, 3, 19)]
        public void minus_method_test(int a, int b, int result)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var mathAction = new MathAction();
            mathAction.ShowMinus(a, b);

            Assert.Equal($"{a} - {b} = {result}\r\n", stringWriter.ToString());
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(6, 1, 6)]
        [InlineData(3, 4, 12)]
        public void multiplied_method_test(int a, int b, int result)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var mathAction = new MathAction();
            mathAction.ShowMultiplied(a, b);

            Assert.Equal($"{a} * {b} = {result}\r\n", stringWriter.ToString());
        }
    }
}
