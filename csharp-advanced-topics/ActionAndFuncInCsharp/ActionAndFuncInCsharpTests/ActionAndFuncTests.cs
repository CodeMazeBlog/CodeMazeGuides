using ActionAndFuncInCsharp;
using System;
using System.IO;
using Xunit;

namespace ActionAndFuncInCSharpTests
{
    public class ActionAndFuncTests : IDisposable
    {
        private readonly StringWriter consoleOutput = new();

        public ActionAndFuncTests()
        {
            Console.SetOut(consoleOutput);
        }      

        [Fact]
        public void WhenTheAddFuncIsDefinedWithLambdaExpression_ThenCallAndInvokeItShouldDisplayCorrectValue()
        {
            Program.AddFuncWithLambdaExpression();

            var addResult = PrintedOutputToArray();

            Assert.Equal("The result of call: 12", addResult[0]);
            Assert.Equal("The result of invoke: 12", addResult[1]);
            Assert.Equal(2, addResult.Length);
        }

        [Fact]
        public void WhenGetPiNumberIsCalled_ThenPrintTheValueOfPiNumber()
        {
            Program.GetPiNumberFuncWithLambdaExpression();

            var pi = PrintedOutputToArray();

            Assert.Equal(Math.PI.ToString(), pi[0]);
            Assert.Single(pi);
        }

        [Fact]
        public void WhenAddFuncIdDefinedWithAnonymousMethod_ThenShouldPrintCorrectValue()
        {
            Program.AddFuncWithAnonymousMethod();

            var addResult = PrintedOutputToArray();

            Assert.Equal("12", addResult[0]);
            Assert.Single(addResult);
        }

        [Fact]
        public void WhenIsEvenNumberFunIdDefinedWithMethodGroup_ThenPrintTrueValueForEvenNumber()
        {
            Program.IsEvenNumberFunWithMethodGroup();

            var isEvent = PrintedOutputToArray();

            Assert.Equal("True", isEvent[0]);
            Assert.Single(isEvent);
        }

        [Fact]
        public void WhenDisplayHelloWorldActionIsDefinedWithLambdaExpression_ThenPrintHelloWorld()
        {
            Program.DisplayHelloWorldActionWithLambdaExpression();

            var helloWrold = PrintedOutputToArray();

            Assert.Equal("Hello World!", helloWrold[0]);
            Assert.Single(helloWrold);
        }

        [Fact]
        public void WhenDisplayResultOfMultiplyActionIsDefinedWithAnonymousMethod_ThenPrintCorrectValueOfMultiply()
        {
            Program.DisplayResultOfMultiplyActionWithAnonymousMethod();

            var multiply = PrintedOutputToArray();

            Assert.Equal("12", multiply[0]);
            Assert.Single(multiply);
        }

        [Fact]
        public void WhenDisplayHelloWorldActionIsDefinedWithMethodGroup_ThenPrintHelloWorld()
        {
            Program.DisplayHelloWorldActionWithMethodGroup();

            var multiply = PrintedOutputToArray();

            var helloWrold = PrintedOutputToArray();

            Assert.Equal("Hello World!", helloWrold[0]);
            Assert.Single(helloWrold);
        }

        public void Dispose()
        {
            consoleOutput.Dispose();
            GC.SuppressFinalize(this);
        }

        private string[] PrintedOutputToArray()
        {
            var printedString = consoleOutput.ToString();
            return printedString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}