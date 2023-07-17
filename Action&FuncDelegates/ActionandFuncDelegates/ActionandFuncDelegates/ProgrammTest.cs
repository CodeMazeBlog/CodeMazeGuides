using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionandFuncDelegates
{
    [TestFixture]
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void PrintMessage_ShouldPrintCorrectMessage()
        {
            // Arrange
            string printedMessage = string.Empty;

            // Act
            Console.SetOut(new System.IO.StringWriter());
            Program.PrintMessage("Hello, Test!");
            printedMessage = Console.Out.ToString().Trim();

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
