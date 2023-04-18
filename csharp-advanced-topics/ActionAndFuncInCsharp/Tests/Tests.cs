using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program = ActionAndFuncInCsharp.Program;


namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void whenActionDelegateCreateWithParameter_thenActionDelegateExecutesTheAnnonymousReferencedMethod()
        {
            // Arrange
            int x = 10;
            int y = 20;
            string expectedOutput = $"Sum of {x} and {y} is {x + y}";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            var program = new Program();
            MethodInfo? methodInfo = typeof(Program).GetMethod("PrintSumUsingActionWithParameter", BindingFlags.NonPublic | BindingFlags.Static);
            methodInfo?.Invoke(program, null);

            // Assert
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void whenActionDelegateCreate_thenActionDelegateExecutesTheAnnonymousReferencedMethod()
        {
            // Arrange
            string expectedOutput = "Hello, World!";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            var program = new Program();
            MethodInfo? methodInfo = typeof(Program).GetMethod("PrintGreetingUsingActionWithoutParameter", BindingFlags.NonPublic | BindingFlags.Static);
            methodInfo?.Invoke(program, null);

            // Assert
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void whenFuncDelegateCreateWithParameter_thenFuncDelegateExecutesTheAnnonymousReferencedMethod()
        {
            // Arrange
            int x = 10;
            int y = 20;
            string expectedOutput = $"Sum of {x} and {y} is {x + y}";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            var program = new Program();
            MethodInfo? methodInfo = typeof(Program).GetMethod("PrintSumUsingFuncWithParameter", BindingFlags.NonPublic | BindingFlags.Static);
            methodInfo?.Invoke(program, null);

            // Assert
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void whenFuncDelegateCreate_thenFuncDelegateExecutesTheAnnonymousReferencedMethod()
        {
            // Arrange
            string expectedOutput = "Hello, World!";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            var program = new Program();
            MethodInfo? methodInfo = typeof(Program).GetMethod("PrintGreetingUsingFuncWithoutParameter", BindingFlags.NonPublic | BindingFlags.Static);
            methodInfo?.Invoke(program, null);

            // Assert
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }

        [TestMethod]
        public void whenMain_thenMainExecutesMethod()
        {
            // Arrange
            string expectedOutput = $"Sum of 10 and 20 is 30{System.Environment.NewLine}Hello, World!{System.Environment.NewLine}Sum of 10 and 20 is 30{System.Environment.NewLine}Hello, World!";
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            var program = new Program();
            MethodInfo? methodInfo = typeof(Program).GetMethod("Main", BindingFlags.NonPublic | BindingFlags.Static);
            methodInfo?.Invoke(program, new object[] { new string[] { } });

            // Assert
            Assert.AreEqual(expectedOutput, consoleOutput.ToString().Trim());
        }
    }
}