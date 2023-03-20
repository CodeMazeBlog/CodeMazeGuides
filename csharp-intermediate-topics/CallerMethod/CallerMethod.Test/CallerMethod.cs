using Moq;
using System.Diagnostics;
using System.Reflection;
using Xunit;

namespace CallerMethod.Test
{
    public class CallerMethod
    {
        [Fact]
        public void WhenPrintCallerName_ThenShouldPrintCallerAndCalledMethodNames()
        {
            // Arrange
            var mockStackTrace = new Mock<StackTrace>();
            mockStackTrace.Setup(s => s.GetFrame(1)).Returns(new StackFrame(1));

            var expectedCallerMethodName = "WhenPrintCallerName_ThenShouldPrintCallerAndCalledMethodNames";
            var expectedCalledMethodName = "PrintCallerName";

            // Act
            ConsoleCapture capture = new();
            using (capture)
            {
                Program.PrintCallerName();
            }

            // Assert
            var output = capture.ToString().Split(Environment.NewLine);
            Assert.Equal("The caller method is: " + expectedCallerMethodName, output[0]);
            Assert.Equal("The called method is: " + expectedCalledMethodName, output[1]);
        }

        [Fact]
        public void WhenPrintCallerNameWithoutStack_ThenShouldPrintCallerAndCalledMethodNames()
        {
            // Arrange
            var mockStackFrame = new Mock<StackFrame>(1, false);
            mockStackFrame.Setup(s => s.GetMethod()).Returns(MethodBase.GetCurrentMethod());

            var expectedCallerMethodName = "WhenPrintCallerNameWithoutStack_ThenShouldPrintCallerAndCalledMethodNames";
            var expectedCalledMethodName = "PrintCallerNameWithoutStack";

            // Act
            ConsoleCapture capture = new();
            using (capture)
            {
                Program.PrintCallerNameWithoutStack();
            }

            // Assert
            var output = capture.ToString().Split(Environment.NewLine);
            Assert.Equal("The caller method is: " + expectedCallerMethodName, output[0]);
            Assert.Equal("The called method is: " + expectedCalledMethodName, output[1]);
        }

        [Fact]
        public void WhenPrintCallerNameWithCallerMemberNameAttribute_ThenShouldPrintCallerAndCalledMethodNames()
        {
            // Arrange
            var mockStackFrame = new Mock<StackFrame>(1, false);
            mockStackFrame.Setup(s => s.GetMethod()).Returns(MethodBase.GetCurrentMethod());

            var expectedCallerMethodName = "WhenPrintCallerNameWithCallerMemberNameAttribute_ThenShouldPrintCallerAndCalledMethodNames";
            var expectedCalledMethodName = "PrintCallerNameWithCallerMemberNameAttribute";

            // Act
            ConsoleCapture capture = new();
            using (capture)
            {
                Program.PrintCallerNameWithCallerMemberNameAttribute();
            }

            // Assert
            var output = capture.ToString().Split(Environment.NewLine);
            Assert.Equal("The caller method is: " + expectedCallerMethodName, output[0]);
            Assert.Equal("The called method is: " + expectedCalledMethodName, output[1]);
        }
    }

}