using System;
using ActionAndFuncDelegates;
using Moq;
using Xunit;

namespace Tests
{
    public class ProgramTests
    {
        [Fact]
        public void ActionDelegate_Add_ShouldPrintSum()
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
        public void ActionDelegate_Greet_ShouldPrintGreeting()
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
        public void FuncDelegate_Add_ShouldReturnSum()
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
        public void FuncDelegate_StringLength_ShouldReturnLength()
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
