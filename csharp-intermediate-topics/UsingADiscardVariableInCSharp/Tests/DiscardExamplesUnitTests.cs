using Discards_;

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

        //Test for GetNumber()
        [Fact]
        public void WhenAnInputIsParsed_ThenReturnTrueIfItIsAValidNumber()
        {
            // Arrange
            var input = "42";
            var expectedOutput = true;

            // Create a TextReader to simulate user input
            var consoleInput = new ConsoleInput(input);
            // Act
            var result = DiscardExamples.GetNumber();

            // Assert
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void WhenAnInputIsParsed_ThenReturnFalseIfItIsNotAValidNumber()
        {
            // Arrange
            var input = "not_a_number";
            var expectedOutput = false;

            // Create a TextReader to simulate user input
            var consoleInput = new ConsoleInput(input);
            // Act
            var result = DiscardExamples.GetNumber();

            // Assert
            Assert.Equal(expectedOutput, result);
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
