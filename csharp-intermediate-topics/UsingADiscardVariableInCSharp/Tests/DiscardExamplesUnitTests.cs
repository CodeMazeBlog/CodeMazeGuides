using Microsoft.VisualStudio.TestPlatform.Utilities;
using UsingADiscardVariableInCSharp;
using Xunit.Sdk;

namespace Tests
{
    public class DiscardExamplesUnitTests
    {
        //Test For GetSum()
        [Fact]
        public void WhenTwoIntsAreAdded_ThenReturnATupleOfTheIntsAndTheirSum()
        {
            // Arrange
            int num1 = 10;
            int num2 = 20;
            (int, int, int) expectedTuple = (num1, num2, num1 + num2);

            // Act
            var result = DiscardExamples.GetSum(num1, num2);

            // Assert
            Assert.Equal(expectedTuple, result);
        }

        [Fact]
        public void WhenAStringIsParsed_ThenReturnTrueIfParseIsSuccessful()
        {
            //Arrange
            var input1 = "s";
            var input2 = "3";

            // Act
            var (result1, errMsg1) = DiscardExamples.GetNumber(input1);
            var (result2, errMsg2) = DiscardExamples.GetNumber(input2);

            // Assert
            Assert.False(result1);
            Assert.Equal("Not a valid number", errMsg1);

            Assert.True(result2);
            Assert.Equal("", errMsg2);
        }

        //Test for GetType()
        [Fact]
        public void WhenIteratingThroughAnArray_ThenConsoleDataTypeOfEachItemInArray()
        {
            // Arrange
            var objects = new object[] { "Hello", 42 };

            // Act
            var output = CaptureConsoleOutput(() => DiscardExamples.GetType(objects));

            // Assert
            Assert.Contains("it's a string", output);
            Assert.Contains("it's an int", output);
            Assert.DoesNotContain("Neither string nor int", output);
        }

        private static string CaptureConsoleOutput(Action action)
        {
            // Redirect console output to capture it
            using var sw = new StringWriter();
            Console.SetOut(sw);
            action.Invoke();
            return sw.ToString().Trim();
        }
    }
}
