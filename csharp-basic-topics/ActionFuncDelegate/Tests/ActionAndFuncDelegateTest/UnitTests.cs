using ActionAndFuncDelegate;
using System;
using Xunit;

namespace ActionAndFuncDelegateTest
{
    public class UnitTests
    {
        StringWriter stringWriter;

        public UnitTests()
        {
            stringWriter = new();
            Console.SetOut(stringWriter);
        }

        [Fact]
        public void WhenCallDelgateIsCalled_CorrectValueIsPrited()
        {
            var expected = "Hello world!\r\n";

            Program.CallDelegate();

            var actual = stringWriter.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenCallActionIsCalled_CorrectValueIsPrinted()
        {
            var expected = "Hello world!\r\n";

            Program.CallDelegate();

            var actual = stringWriter.ToString();

            Assert.Equal(expected, actual);
        }
    }
}