using System;
using System.IO;
using System.Text;
using Xunit;

namespace ActionFuncDelegatesTest
{
    public class ProgramTests : IDisposable
    {
        private readonly StringWriter _stringWriter;

        public ProgramTests()
        {
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        public void Dispose()
        {
            _stringWriter.Dispose();
        }

        [Fact]
        public void When_GreetCalled_Then_DisplayGreetingMessage()
        {
            // Arrange
            Action greetMessage = ActionFuncDelegates.DelegateMethods.Greet;

            // Act
            greetMessage();

            // Assert
            string expectedOutput = "Hello, how can I help you?";
            string actualOutput = _stringWriter.ToString().TrimEnd();
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void When_GreetWithNameCalled_Then_DisplayGreetingMessageWithName()
        {
            // Arrange
            Action<string> greetWithName = ActionFuncDelegates.DelegateMethods.GreetWithName;
            string name = "Tanveer";

            // Act
            greetWithName(name);

            // Assert
            string expectedOutput = $"Hello {name}, how can I help you?";
            string actualOutput = _stringWriter.ToString().TrimEnd();
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void When_PercentageScoreCalled_Then_ReturnPercentageScore()
        {
            // Arrange
            Func<int, int, double> percentageScore = ActionFuncDelegates.DelegateMethods.PercentageScore;
            int totalMarks = 100;
            int obtainedMarks = 70;

            // Act
            double result = percentageScore(totalMarks, obtainedMarks);

            // Assert
            double expectedOutput = 70.0;
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void When_GetFullnameCalled_Then_ReturnFullName()
        {
            // Arrange
            Func<string, string, string> getFullname = ActionFuncDelegates.DelegateMethods.GetFullname;
            string firstName = "Tanveer";
            string lastName = "Hussain";

            // Act
            string result = getFullname(firstName, lastName);

            // Assert
            string expectedOutput = $"{firstName} {lastName}";
            Assert.Equal(expectedOutput, result);
        }
    }
}
