using System;
using ActionAndFuncDelegates;
using Moq;
using Xunit;

namespace Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Given_ActionDelegate_When_Execute_Should_PrintSum()
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
        public void Given_ActionDelegate_When_Execute_Should_PrintGreeting()
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
        public void Given_FuncDelegate_When_Execute_Should_ReturnSum()
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
        public void Given_FuncDelegate_When_Execute_Should_ReturnStringLength()
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
