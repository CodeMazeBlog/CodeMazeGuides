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

        // As seen in the article, we can't test the TopLevelProgram.cs, since we have no accessible class to import.
        // To manually test it, simply run the program, as the compiler will ignore the `Main()` method if top-level statements are present
    }
}