using System.Reflection;
using System.Text;

namespace ActionAndFuncDelegatesInCSharp.Test
{
    public class ActionUnitTest
    {
        [Fact]
        public void WhenCallGoodbye_ThenResultIsString()
        {
            // Arrange
            var goodbyeAction = Program.SayGoodbye;
            var expectedOutput = "Message: Goodbye John" + Environment.NewLine;

            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act
            Program.InteractAction(goodbyeAction, "John");

            // Assert
            Assert.Equal(expectedOutput, sb.ToString());
        }

        [Fact]
        public void WhenCallHello_ThenLogCorrectResult()
        {
            // Arrange
            var helloAction = Program.SayHello;
            var expectedOutput = "Message: Hello John" + Environment.NewLine;

            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act
            Program.InteractAction(helloAction, "John");

            // Assert
            Assert.Equal(expectedOutput, sb.ToString());
        }
    }
}
