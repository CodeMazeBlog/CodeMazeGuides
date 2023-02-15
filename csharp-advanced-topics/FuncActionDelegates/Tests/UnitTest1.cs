using FuncActionDelegatesCodeMaze;

namespace Tests
    
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PrintToConsoleUnitTest()
        {
            // Given
            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);

            var message = "Hello, world!";

            // When
            FuncActionDelegatesCodeMaze.Program.PrintToConsole(message);

            // Then
            var expectedOutput = $"Custom print - {message}\r\n";
            Assert.That(consoleOut.ToString(), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void AddUnitTest()
        {
            // Given 
            double n1 = 9.7;
            double n2 = 12.6;
            double expectedSum = n1 + n2;

            // When
            double actualSum = FuncActionDelegatesCodeMaze.Program.Add(n1, n2);

            // Then
            Assert.That(actualSum, Is.EqualTo(expectedSum).Within(0.001)); // using delta to ignore small differences due to floating point arithmetic
        }
    }
}