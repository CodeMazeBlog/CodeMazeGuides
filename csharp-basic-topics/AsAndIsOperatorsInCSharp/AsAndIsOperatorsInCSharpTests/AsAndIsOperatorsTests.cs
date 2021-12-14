using Application;
using System;
using System.IO;
using Xunit;

namespace AsAndIsOperatorsInCSharpTests
{
    public class AsAndIsOperatorsTests : IDisposable
    {
        private readonly StringWriter output = new();

        public AsAndIsOperatorsTests()
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
        public void WhenEqualityVsTypeComparison_ThenPrintThatComparisonsAreValid()
        {
            Program.EqualityVsTypeComparison();

            var equalityArray = PrintedOutputToArray();

            Assert.Equal("Both comparisons are valid", equalityArray[0]);
            Assert.Single(equalityArray);
        }

        [Fact]
        public void WhenIsCowAnAnimal_ThenPrintFalseAndTrue()
        {
            Program.IsCowAnAnimal();

            var comparisonArray = PrintedOutputToArray();

            Assert.Equal("False", comparisonArray[0]);
            Assert.Equal("True", comparisonArray[1]);
            Assert.Equal(2, comparisonArray.Length);
        }

        [Fact]
        public void WhenCanCowBeAsAnimal_ThenShouldPrintTrue()
        {
            Program.CanCowBeAsAnimal();

            var comparisonArray = PrintedOutputToArray();

            Assert.Equal("True", comparisonArray[0]);
            Assert.Single(comparisonArray);
        }

        [Fact]
        public void WhenCanObjectBeAsCow_ThenPrintThatObjectIsNull()
        {
            Program.CanObjectBeAsCow();

            var comparisonArray = PrintedOutputToArray();

            Assert.Equal("The object is null", comparisonArray[0]);
            Assert.Single(comparisonArray);
        }

        [Fact]
        public void GivenNullAndNonNull_WhenHumanFriendlyNullCheck_ThenCheckNullCorrectly()
        {
            object nonNullObject = new();
            object nullObject = null;

            var nullCheckTrue = Program.HumanFriendlyNullCheck(nonNullObject);
            var nullCheckFalse= Program.HumanFriendlyNullCheck(nullObject);

            Assert.Equal($"This {typeof(object)} is not null", nullCheckTrue);
            Assert.Equal($"This {typeof(object)} is null", nullCheckFalse);
        }

        [Fact]
        public void WhenAsVsCastInvalidHandling_ThenPrintInvalidChecks()
        {
            Program.AsVsCastInvalidHandling();

            var comparisonArray = PrintedOutputToArray();

            Assert.Equal("This verifies that a conversion was not valid using an 'as' operator", comparisonArray[0]);
            Assert.Equal("This verifies that a conversion was not valid using a cast expression", comparisonArray[1]);
            Assert.Equal(2, comparisonArray.Length);
        }
    }
}