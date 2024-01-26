using System;
using ActionAndFuncDelegates;
using Moq;
using Xunit;

namespace Tests
{
    public class ProgramTests
    {
        [Fact]
        public void GivenActionDelegate_WhenExecuting_ThenShouldPrintSum() 
        {
            // Arrange
            var mockConsoleWriter = new Mock<IConsoleWriter>();
            mockConsoleWriter.Setup(c => c.WriteLine(It.IsAny<string>())).Callback<string>((message) =>
            {
                Console.WriteLine(message);
            }).Verifiable();
            var program = new Program(mockConsoleWriter.Object);

            // Act
            program.ActionDelegate();

            // Assert
            mockConsoleWriter.Verify();
        }

        [Fact]
        public void GivenActionDelegate_WhenExecuting_ThenShouldPrintGreeting()
        {
            // Arrange
            var mockConsoleWriter = new Mock<IConsoleWriter>();
            mockConsoleWriter.Setup(c => c.WriteLine(It.IsAny<string>())).Callback<string>((message) =>
            {
                Console.WriteLine(message);
            }).Verifiable();
            var program = new Program(mockConsoleWriter.Object);

            // Act
            program.ActionDelegate();

            // Assert
            mockConsoleWriter.Verify();
        }

        [Fact]
        public void GivenFuncDelegate_WhenExecuting_ThenShouldReturnSum()
        {
            // Arrange
            var mockConsoleWriter = new Mock<IConsoleWriter>();
            mockConsoleWriter.Setup(c => c.WriteLine(It.IsAny<string>())).Callback<string>((message) =>
            {
                Console.WriteLine(message);
            }).Verifiable();
            var program = new Program(mockConsoleWriter.Object);

            // Act
            int result = program.FuncDelegate();

            // Assert
            Assert.Equal(16, result);
            mockConsoleWriter.Verify();
        }

        [Fact]
        public void GivenFuncDelegate_WhenExecuting_ThenShouldReturnStringLength()
        {
            // Arrange
            var mockConsoleWriter = new Mock<IConsoleWriter>();
            mockConsoleWriter.Setup(c => c.WriteLine(It.IsAny<string>())).Callback<string>((message) =>
            {
                Console.WriteLine(message);
            }).Verifiable();
            var program = new Program(mockConsoleWriter.Object);

            // Act
            int result = program.FuncDelegate();

            // Assert
            Assert.Equal(16, result);
            mockConsoleWriter.Verify();
        }
    }
}
