using System.Reflection;
using System.Text;

namespace ActionAndFuncDelegatesInCSharp.Test
{
    public class ActionUnitTest
    {
        [Fact]
        public void WhenCallGoodbye_ThenLogCorrectResult()
        {
            // Arrange
            var goodbyeAction = typeof(ActionUnitTest).GetMethod("SayGoodbye", BindingFlags.NonPublic | BindingFlags.Static);
            var interactAction = typeof(ActionUnitTest).GetMethod("InteractAction", BindingFlags.NonPublic | BindingFlags.Static);

            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act
            interactAction.Invoke(null, new object[] { goodbyeAction, "John" });

            // Assert
            string expectedOutput = "Message: Goodbye John" + Environment.NewLine;
            Assert.Equal(expectedOutput, sb.ToString());
        }

        [Fact]
        public void WhenCallHello_ThenLogCorrectResult()
        {
            // Arrange
            var helloAction = typeof(ActionUnitTest).GetMethod("SayHello", BindingFlags.NonPublic | BindingFlags.Static);
            var interactAction = typeof(ActionUnitTest).GetMethod("InteractAction", BindingFlags.NonPublic | BindingFlags.Static);

            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));

            // Act
            interactAction.Invoke(null, new object[] { helloAction, "John" });

            // Assert
            string expectedOutput = "Message: Hello John" + Environment.NewLine;
            Assert.Equal(expectedOutput, sb.ToString());
        }

        private static void InteractAction(MethodInfo action, string message)
        {
            action.Invoke(null, new object[] { message });
        }

        private static void SayGoodbye(string name)
        {
            string message = $"Goodbye {name}";
            Console.WriteLine($"Message: {message}");
        }

        private static void SayHello(string name)
        {
            string message = $"Hello {name}";
            Console.WriteLine($"Message: {message}");
        }
    }
}
