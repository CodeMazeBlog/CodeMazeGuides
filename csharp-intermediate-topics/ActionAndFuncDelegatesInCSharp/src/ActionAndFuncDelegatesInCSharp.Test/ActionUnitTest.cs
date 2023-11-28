using System.Text;

namespace ActionAndFuncDelegatesInCSharp.Test
{
    public class ActionUnitTest
    {
        [Fact]
        public void WhenCallGoodbye_ThenResultContainsGoodbye()
        {
            // Arrange
            var goodbyeAction = Program.SayGoodbye;
            var expectedOutput = "Message: Goodbye John" + Environment.NewLine;

            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act
            Program.InteractAction(goodbyeAction, "John");

            // Assert
            Assert.Contains(expectedOutput, sb.ToString());
        }

        [Fact]
        public void WhenCallGoodbye_ThenResultContainsMinimumThreeWords()
        {
            // Arrange
            var goodbyeAction = Program.SayGoodbye;
            var expectedOutput = "Message: Goodbye John" + Environment.NewLine;

            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act
            Program.InteractAction(goodbyeAction, "John");

            // Assert
            Assert.True(sb.ToString().Split(' ').Length >= 3);
        }

        [Fact]
        public void WhenCallHello_ThenResultContainsHello()
        {
            // Arrange
            var helloAction = Program.SayHello;
            var expectedOutput = "Message: Hello John" + Environment.NewLine;

            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act
            Program.InteractAction(helloAction, "John");

            // Assert
            Assert.Contains(expectedOutput, sb.ToString());
        }

        [Fact]
        public void WhenCallHello_ThenResultContainsMinimumThreeWords()
        {
            // Arrange
            var helloAction = Program.SayHello;
            var expectedOutput = "Message: Hello John" + Environment.NewLine;

            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act
            Program.InteractAction(helloAction, "John");

            // Assert
            Assert.True(sb.ToString().Split(' ').Length >= 3);
        }
    }
}
