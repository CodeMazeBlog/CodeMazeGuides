using ActionAndFuncDelegatesCSharp;
using System;
using System.IO;
using Xunit;

namespace Tests
{
    public class ActionAndFuncUnitTests : IDisposable
    {
        private readonly StringWriter output = new();

        public ActionAndFuncUnitTests()
        {
            Console.SetOut(output);
        }

        public void Dispose()
        {
            output.Dispose();
            GC.SuppressFinalize(this);
        }

        public string[] PrintedOutputToArray()
        {
            var printedString = output.ToString();
            return printedString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        [Fact]
        public void NamedDelegateVsActionComparison_ShouldPrintHelloWorldTwice()
        {
            Program.NamedDelegateVsActionComparison();

            var helloWorldArray = PrintedOutputToArray();

            Assert.Equal("Hello world!", helloWorldArray[0]);
            Assert.Equal("Hello world!", helloWorldArray[1]);
            Assert.Equal(2, helloWorldArray.Length);
        }

        [Fact]
        public void ActionAndFuncUsageExample_ShouldPrintCorrectNumbers()
        {
            Program.ActionAndFuncUsageExample();

            var printedNumbersArray = PrintedOutputToArray();

            Assert.Equal("1, 2, 2.2", printedNumbersArray[0]);
            Assert.Equal("3, 12, 11.1", printedNumbersArray[1]);
            Assert.Equal(2, printedNumbersArray.Length);
        }
    }
}
