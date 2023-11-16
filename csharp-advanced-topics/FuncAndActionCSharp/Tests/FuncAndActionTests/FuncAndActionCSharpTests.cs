using NSubstitute.Core.Arguments;
using System.ComponentModel;

namespace FuncAndActionCSharpTests
{
    public class FuncAndActionCSharpTests
    {
        [Fact]
        public void Func_PerformFiltration_ShouldFilterEvenNumbers()
        {
            // Arrange
            var func = new FuncDelegate();
            var numbers = new List<int> { 42, 18, 7, 31, 55, 89, 23, 14, 68, 37, 91, 12, 63, 29, 50, 5, 18, 7, 31, 55, 89, 23, 14, 68, 37, 91, 12, 63, 29, 50, 5, 82 };

            // Act
            var result = func.PerformFiltration(numbers);

            // Assert
            Assert.Equal(12, result.Count());
            Assert.Equal(new List<int> { 42, 18, 14, 68, 12, 50, 18, 14, 68, 12, 50, 82 }, result);
        }

        [Fact]
        public void Action_LogsMessageUsingLogger_InformationType()
        {
            // Arrange
            var actionDelegate = new ActionDelegate();
            var loggerSubs = Substitute.For<Action<string>>();
            var message = "The request was intercepted by filtering middleware.";

            // Act
            actionDelegate.Information(loggerSubs, message);

            // Assert
            loggerSubs.Received(1).Invoke(message);
        }

        [Fact]
        public void Action_LogsMessageUsingLogger_WarningType()
        {
            // Arrange
            var actionDelegate = new ActionDelegate();
            var loggerSubs = Substitute.For<Action>();

            // Act
            actionDelegate.Warning(loggerSubs);

            // Assert
            loggerSubs.Received(1).Invoke();
        }

        [Fact]
        public void Action_LogsMessageUsingLogger_ErrorType()
        {
            // Arrange
            var actionDelegate = new ActionDelegate();
            var loggerSubs = Substitute.For<Action<string>>();
            var message = "Invalid request error";

            using var output = new StringWriter();

            Console.SetOut(output);

            // Act
            actionDelegate.Error(message);

            // Assert
            loggerSubs.Received(1);
        }

        [Fact]
        public void InformationLevelConsoleLogger_PrintsMessageToConsole()
        {
            // Arrange
            var logMessage = "The operation finished in 1.1 sec";
            var delegateIntroduction = new Delegate();
           
            var consoleLogger = Substitute.ForPartsOf<Delegate>();
            consoleLogger.When(
                x => x.InformationLevelConsoleLogger(
                    Arg.Any<string>()))
                .CallBase();

            // Act
            consoleLogger.InformationLevelConsoleLogger(logMessage);

            // Assert
            consoleLogger.Received()
                .InformationLevelConsoleLogger(logMessage);
        }

        [Fact]
        public void InvokeSimpleDelegate_InvokesLogger()
        {
            // Arrange
            var logMessage = "The operation finished in 1.1 sec";
            var delegateIntroduction = new Delegate();
           
            var consoleLogger = Substitute.ForPartsOf<Delegate>();
            consoleLogger.When(
                x => x.InformationLevelConsoleLogger(
                    Arg.Any<string>()))
                .CallBase();

            // Act
            using var output = new StringWriter();

            Console.SetOut(output);

            consoleLogger.InvokeSimpleDelegate();
            var expectedOutput = $"Additional information: {logMessage}\r\nAdditional information: {logMessage}\r\n";

            // Assert
            Assert.Equal(expectedOutput, output.ToString());
        }
    }
}