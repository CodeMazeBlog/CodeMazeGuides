

using ActionAndFuncInCsharpConsole;

namespace ActionsAndFuncInCsharpTests;


public class ActionExamplesTests 
{
        private List<string> _logs;

        public ActionExamplesTests()
        {
            _logs = new List<string>();
        }

        private void Log(string message)
        {
            _logs.Add(message);
        }

        [Fact]
        public void Compute2_LogsStartAndEnd()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            actionExamples.LoggerInfo = Log;

            // Act
            actionExamples.Compute2(actionExamples.LoggerInfo);

            // Assert
            Assert.Equal(2, _logs.Count);
            Assert.Equal("Starting Job", _logs.First());
            Assert.Equal("Job Operation Completed", _logs.Last());
        }

        [Fact]
        public void DoSomeWork_LogsEmailAndSms()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            actionExamples.LoggerInfo = Log;

            // Act
            actionExamples.DoSomeWork();

            // Assert
            Assert.Equal(2, _logs.Count);
            Assert.Equal("send sms completed", _logs.First());
            Assert.Equal("send email completed", _logs.Last());
        }

        [Fact]
        public void Print_WithMessage_LogsMessage()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            actionExamples.LoggerInfo = Log;
            string message = "Test message";

            // Act
            actionExamples.Print(message);

            // Assert
            Assert.Single(_logs);
            Assert.Equal(message, _logs.First());
        }

        [Fact]
        public void Print_WithoutMessage_LogsDefaultMessage()
        {
            // Arrange
            var actionExamples = new ActionExamples();
            actionExamples.LoggerInfo = Log;

            // Act
            actionExamples.Print();

            // Assert
            Assert.Single(_logs);
            Assert.Equal("logging message", _logs.First());
        }
    
    }




