using ActionFuncDelegates;

namespace Tests
{
    public class FuncDelegatesTests
    {
        [Fact]
        public void TestFuncDelegate()
        {
            // Arrange
            var expected = 30;

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var result = FuncDelegates.FuncDelegate();
                var consoleOutput = sw.ToString();

                // Assert
                Assert.Equal(expected, result);
                Assert.Contains($"Result:{expected}", consoleOutput);
            }
        }

        [Fact]
        public void TestFuncDelegateWithAnonymous()
        {
            // Arrange
            var expected = 40;

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var result = FuncDelegates.FuncDelegateWithAnonymous();
                var consoleOutput = sw.ToString();

                // Assert
                Assert.Equal(expected, result);
                Assert.Contains($"Result:{expected}", consoleOutput);
            }
        }


        [Fact]
        public void TestFuncDelegateWithLambda()
        {
            // Arrange
            var expected = 100;

            // Create a StringWriter to capture console output
            using (var sw = new StringWriter())
            {
                // Save the current Console.Out
                var originalConsoleOut = Console.Out;

                try
                {
                    // Redirect Console.Out to the StringWriter
                    Console.SetOut(sw);

                    // Act
                    var resultTuple = FuncDelegates.FuncDelegateWithLambda();
                    var result = resultTuple.Result; // Corrected property name
                    var consoleOutput = sw.ToString();

                    // Debugging output
                    Console.WriteLine($"Actual Result: {result}");
                    Console.WriteLine($"Actual Console Output: {consoleOutput}");

                    // Assert
                    Assert.Equal(expected, result);
                    Assert.Contains($"{expected}", consoleOutput); // Use Assert.Contains without formatting
                }
                finally
                {
                    // Restore the original Console.Out
                    Console.SetOut(originalConsoleOut);
                }
            }
        }

    }
}


