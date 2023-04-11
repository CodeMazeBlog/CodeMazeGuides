using System;
using System.IO;
using System.Text;
using Xunit;

namespace ActionFuncDelegatesTest
{
    public class ProgramTests : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly StringBuilder _outputBuilder;
        public ProgramTests()
        {
            _stringWriter = new StringWriter();
            _outputBuilder = new StringBuilder();
            Console.SetOut(_stringWriter);
        }
        public void Dispose()
        {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            string output = _stringWriter.ToString();
            _outputBuilder.Append(output);
            _stringWriter.Dispose();
        }
        [Fact]
        public void TestActionDelegate_Greet()
        {
            // Arrange
            Action greetMessage = ActionFuncDelegates.Program.Greet;
            // Act
            greetMessage();
            // Assert
            string expectedOutput = "Hello, how can I help you?";
            string actualOutput = _outputBuilder.ToString().TrimEnd();
            Assert.Equal(expectedOutput, actualOutput);
        }
        [Fact]
        public void TestActionDelegate_GreetWithName()
        {
            // Arrange
            Action<string> greetWithName = ActionFuncDelegates.Program.GreetWithName;
            string name = "Tanveer";
            // Act
            greetWithName(name);
            // Assert
            string expectedOutput = $"Hello {name}, how can I help you?";
            string actualOutput = _outputBuilder.ToString().TrimEnd();
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void TestFuncDelegate_PercentageScore()
        {
            // Arrange
            Func<int, int, double> percentageScore = ActionFuncDelegates.Program.PercentageScore;
            int totalMarks = 100;
            int obtainedMarks = 70;
            // Act
            double result = percentageScore(totalMarks, obtainedMarks);
            // Assert
            double expectedOutput = 70.0;
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void TestFuncDelegate_GetFullname()
        {
            // Arrange
            Func<string, string, string> getFullname = ActionFuncDelegates.Program.GetFullname;
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
