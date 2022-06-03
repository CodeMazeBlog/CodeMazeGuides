using Xunit;

namespace dotnet_console.Tests
{
    public class ConsoleTests
    {
        StringWriter _testWriter = new StringWriter();

        [Fact]
        public void HelloWorld_Outputs()
        {
            // Arrange

            // Act
            BasicInputOutput.HelloWorld();

            // Assert
            var sb = _testWriter.GetStringBuilder();
            Assert.Equal("Hello, World!", sb.ToString().Trim());
        }

        [Fact]
        public void AskName_InputOuput()
        {
            // Arrange
            var textReader = new StringReader("Gavin");
            Console.SetIn(textReader);

            // Act
            BasicInputOutput.AskName();

            // Assert
            var sb = ((StringWriter)_testWriter).GetStringBuilder();
            var lines = sb.ToString().Split(Environment.NewLine, StringSplitOptions.TrimEntries);
            Assert.Equal("Hello, Gavin", lines[1]);

        }

        public ConsoleTests()
        {
            Console.SetOut(_testWriter);
        }
    }
}