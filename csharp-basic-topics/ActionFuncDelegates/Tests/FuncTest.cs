using ActionFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{

    public class FuncDelegatesTests
    {
        [Fact]
        public void TestFuncDelegate()
        {
            // Arrange
            int expected = 30;

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                int result = FuncDelegates.FuncDelegate();
                string consoleOutput = sw.ToString();

                // Assert
                Assert.Equal(expected, result);
                Assert.Contains($"Result:{expected}", consoleOutput);
            }
        }

        [Fact]
        public void TestFuncDelegateWithAnonymous()
        {
            // Arrange
            int expected = 40;

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                int result = FuncDelegates.FuncDelegateWithAnonymous();
                string consoleOutput = sw.ToString();

                // Assert
                Assert.Equal(expected, result);
                Assert.Contains($"Result:{expected}", consoleOutput);
            }
        }




        [Fact]
        public void TestFuncDelegateWithLambda()
        {
            // Arrange
            int expected = 100;

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
                    int result = resultTuple.Result; // Corrected property name
                    string consoleOutput = sw.ToString();

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


