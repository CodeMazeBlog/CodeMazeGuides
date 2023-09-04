using Discards_;

namespace Tests
{
    public class DiscardExamplesUnitTests
    { 
        [Fact]
        public void GivenAnItemInAnArray_ShouldReturnValidOutput()
        {
            // Arrange
            var discardExamples = new DiscardExamples();
            var objects = new object[] { "Hello", 42 };

            // Act
            var output = CaptureConsoleOutput(() => discardExamples.GetType(objects));

            // Assert
            Assert.Contains("it's a string", output);
            Assert.Contains("it's an int", output);
            Assert.DoesNotContain("Neither string nor int", output);
        }

        private static string CaptureConsoleOutput(Action action)
        {
            // Redirect console output to capture it
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                action.Invoke();
                return sw.ToString().Trim();
            }
        }
    }
}
