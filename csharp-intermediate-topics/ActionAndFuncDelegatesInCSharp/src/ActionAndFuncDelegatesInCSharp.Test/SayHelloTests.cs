namespace ActionAndFuncDelegatesInCSharp.Test
{
    [TestClass]
    public class SayHelloTests
    {
        // Action delegate
        private readonly Action<string> SayHello = (string name) => Console.WriteLine($"Hello {name}!");

        [TestMethod]
        public void SayHello_ValidName_PrintsHello()
        {
            // Arrange - Setting up the test
            string expectedOutput = "Hello John!";
            string actualOutput = null;

            // Redirect console output to capture it
            using (var consoleOutput = new ConsoleOutput())
            {
                // Act - Invoking the Action delegate
                SayHello("John");
                actualOutput = consoleOutput.GetOutput();
            }

            // Assert - Verifying the output matches the expected result
            Assert.AreEqual(expectedOutput, actualOutput.Trim());
        }

        // Helper class to capture console output
        public class ConsoleOutput : IDisposable
        {
            private readonly TextWriter originalOutput;
            private readonly StringWriter stringWriter;

            public ConsoleOutput()
            {
                stringWriter = new StringWriter();
                originalOutput = Console.Out;
                Console.SetOut(stringWriter);
            }

            public void Dispose()
            {
                stringWriter.Dispose();
                Console.SetOut(originalOutput);
            }

            public string GetOutput()
            {
                return stringWriter.ToString();
            }
        }
    }
}
