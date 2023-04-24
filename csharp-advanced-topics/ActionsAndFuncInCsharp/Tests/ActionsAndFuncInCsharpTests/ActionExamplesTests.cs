

using ActionAndFuncInCsharpConsole;

namespace ActionsAndFuncInCsharpTests;


public class ActionExamplesTests
    {
        [Fact]
        public void Print_ShouldWriteToConsole()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            var consoleOutput = new ConsoleOutput();

            // Act
            actionExamples.Print();
            var output = consoleOutput.GetOutput();

            // Assert
            Assert.Contains("logging message", output);
        }

        [Fact]
        public void Print_WithMessage_ShouldWriteToConsole()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            var consoleOutput = new ConsoleOutput();

            // Act
            actionExamples.Print("Test message");
            var output = consoleOutput.GetOutput();

            // Assert
            Assert.Contains("Test message", output);
        }

        [Fact]
        public void Compute_ShouldWriteToConsole()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            var consoleOutput = new ConsoleOutput();

            // Act
            actionExamples.Compute(null);
            var output = consoleOutput.GetOutput();

            // Assert
            Assert.Contains("Operation started", output);
        }

        [Fact]
        public void Compute2_ShouldCallLoggerInfoAction()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            var loggerInfoCalled = false;
            Action<string> loggerInfo = s => loggerInfoCalled = true;

            // Act
            actionExamples.Compute2(loggerInfo);

            // Assert
            Assert.True(loggerInfoCalled);
        }

        [Fact]
        public void SendMessage_ShouldCallNotifyAction()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            var notifyCalled = false;
            Action<string, string> notify = (s1, s2) => notifyCalled = true;

            // Act
            actionExamples.SendMessage("Test message", "+123456789", notify);

            // Assert
            Assert.True(notifyCalled);
        }

        [Fact]
        public void DoSomeWork_ShouldCallSendSmsAndSendEmail()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            var sendSmsCalled = false;
            var sendEmailCalled = false;
            Action<string, string> sendSms = (s1, s2) => sendSmsCalled = true;
            Action<string, string> sendEmail = (s1, s2) => sendEmailCalled = true;

            // Act
            actionExamples.SendMessage("Test message", "+123456789", sendSms);
            actionExamples.SendMessage("Test message", "test@example.com", sendEmail);

            // Assert
            Assert.True(sendSmsCalled);
            Assert.True(sendEmailCalled);
        }

        [Fact]
        public void DoSomeWork2_ShouldCallPrint()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            var printCalled = false;
            Action<string> print = s => printCalled = true;

            // Act
            actionExamples.Compute2(print);

            // Assert
            Assert.True(printCalled);
        }
    }




