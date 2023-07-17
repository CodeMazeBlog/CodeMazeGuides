using ActionandFuncDelegates;
using NUnit.Framework;
using System;
using System.IO;

namespace DelegateDemo
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void PrintMessage_ShouldPrintCorrectMessage()
        {
            // Arrange
            string printedMessage;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Program.PrintMessage("Hello, Test!");
            printedMessage = stringWriter.ToString().Trim();

            // Assert
            Assert.AreEqual("Hello, Test!", printedMessage);
        }

        [Test]
        public void AddNumbers_ShouldReturnCorrectSum()
        {
            // Arrange
            int expectedResult = 10;

            // Act
            int result = Program.AddNumbers(3, 7);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}