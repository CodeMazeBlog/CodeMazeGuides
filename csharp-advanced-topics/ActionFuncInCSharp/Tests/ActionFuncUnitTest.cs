using ActionFuncInCSharp;
using System.Text;

namespace Tests
{
    public class ActionFuncUnitTest
    {
        [Fact]
        public void WhenHelloUserNotificationIsSent_ActionDelegateExecutesTheReferencedMethod()
        {

            // Arrange
            var sb = new StringBuilder();
            Action<string> emailAction = (msg) => sb.AppendLine($"Sending email: {msg}");

            var originalOut = Console.Out;
            using (var writer = new StringWriter(sb))
            {
                Console.SetOut(writer);

                // Act
                NotifierAction.SendNotification("Hello, user!", emailAction);
            }

            // Assert
            string capturedOutput = sb.ToString();
            Assert.Contains("Preparing to send notification: Hello, user!", capturedOutput);
            Assert.Contains("Sending email: Hello, user!", capturedOutput);
        }

        [Fact]
        public void WhenImportantUpdateNotificationIsSent_ActionDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var sb = new StringBuilder();
            Action<string> smsAction = (msg) => sb.AppendLine($"Sending SMS: {msg}");

            var originalOut = Console.Out;
            using (var writer = new StringWriter(sb))
            {
                Console.SetOut(writer);

                // Act
                NotifierAction.SendNotification("Important update!", smsAction);
            }

            // Assert
            string capturedOutput = sb.ToString();
            Assert.Contains("Preparing to send notification: Important update!", capturedOutput);
            Assert.Contains("Sending SMS: Important update!", capturedOutput);
        }

        [Fact]
        public void WhenNewContentNotificationIsSent_ActionDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var sb = new StringBuilder();
            Action<string> pushAction = (msg) => sb.AppendLine($"Sending push notification: {msg}");

            var originalOut = Console.Out;
            using (var writer = new StringWriter(sb))
            {
                Console.SetOut(writer);

                // Act
                NotifierAction.SendNotification("New content available!", pushAction);
            }

            // Assert
            string capturedOutput = sb.ToString();
            Assert.Contains("Preparing to send notification: New content available!", capturedOutput);
            Assert.Contains("Sending push notification: New content available!", capturedOutput);
        }

        //write a test for the DataProcessorFunc.ProcessData method
        [Fact]
        public void WhenBasicProcessingIsApplied_DataProcessorFuncExecutesTheReferencedMethod()
        {
            // Arrange
            Func<string, string> basicProcessFunc = (data) => $"Basic processing: {data}";
            var sb = new StringBuilder();

            var originalOut = Console.Out;
            using (var writer = new StringWriter(sb))
            {
                Console.SetOut(writer);

                // Act
                string result1 = DataProcessorFunc.ProcessData("Sample data", basicProcessFunc);

                // Assert
                Assert.Contains("Basic processing: Sample data", result1);
            }
            // Assert
            string capturedOutput = sb.ToString();
            Assert.Contains("Preparing to process data: Sample data", capturedOutput);
        }

        [Fact]
        public void WhenAdvancedProcessingIsApplied_DataProcessorFuncExecutesTheReferencedMethod()
        {
            // Arrange
            Func<string, string> advancedProcessFunc = (data) => $"Advanced processing: {data}";
            var sb = new StringBuilder();

            var originalOut = Console.Out;
            using (var writer = new StringWriter(sb))
            {
                Console.SetOut(writer);

                // Act
                string result1 = DataProcessorFunc.ProcessData("Sample data", advancedProcessFunc);

                // Assert
                Assert.Contains("Advanced processing: Sample data", result1);
            }

            // Assert
            string capturedOutput = sb.ToString();
            Assert.Contains("Preparing to process data: Sample data", capturedOutput);
        }
    }
}