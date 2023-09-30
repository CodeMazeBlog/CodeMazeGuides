namespace InterceptorsInCSharp.Tests
{
    public class Tests
    {
        [Test]
        public void GivenICallTheRunMethod__ThenItShouldReturnTheValueFromTheInterceptingMethod()
        {
            //Arrange
            const string expectedText = "Hello, Code Maze!\r\nGreetings, Code Maze!\r\n";
            using var consoleTester = new ConsoleOutputTester();

            //Act
            Program.Main([]);
            var response = consoleTester.GetOutput();

            //Assert
            Assert.That(response, Is.EqualTo(expectedText));
        }
    }
}