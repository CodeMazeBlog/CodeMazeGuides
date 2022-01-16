using KitchenEntities;
using System;
using System.IO;
using Xunit;

namespace TopLevelStatementsInCSharpTests
{
    public class TopLevelStatementsTests : IDisposable
    {
        private readonly StringWriter output = new();
        private readonly string _expectedOutput = "I freeze your food!";

        public TopLevelStatementsTests()
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
        public void WhenFridgeApplianceFunctionality_ThenPrintOutput()
        {
            Fridge.ApplianceFunctionality();

            var equalityArray = PrintedOutputToArray();

            Assert.Equal(_expectedOutput, equalityArray[0]);
            Assert.Single(equalityArray);
        }

        [Fact]
        public void WhenRunOldStyleMain_ThenPrintOutput()
        {
            Program.Main(Array.Empty<string>());

            var equalityArray = PrintedOutputToArray();

            Assert.Equal(_expectedOutput, equalityArray[0]);
            Assert.Single(equalityArray);
        }

        [Fact]
        public void WhenRunTopLevelStatements_ThenPrintOutput()
        {
            var entryPoint = typeof(Program).Assembly.EntryPoint!;
            entryPoint.Invoke(null, new object[] { Array.Empty<string>() });

            var equalityArray = PrintedOutputToArray();

            Assert.Equal(_expectedOutput, equalityArray[0]);
            Assert.Single(equalityArray);
        }
    }
}