using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class DelegateUnitTest
    {

        [TestMethod]
        public void WhenActionDelegate_DelegateInvocationToAddTwoNumbers()
        {
            // Arrange
            int a = 5;
            int b = 3;
            Action addDelegate = () => ActionAndFuncDelegatesInCsharp.Program.Add(a, b);

            // Redirect Console output to a StringWriter
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            addDelegate(); // Output: Addition Result: 8

            // Assert
            string expectedOutput = $"Addition Result: {a + b}\r\n";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString());

            // Clean up: Restore Console output
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        [TestMethod]
        public void WhenFuncDelegate_DelegateInvocationToMultiplyNumbers()
        {
            int expected = 24;
            // Arrange
            Func<int, int, int> multiplyDelegate = ActionAndFuncDelegatesInCsharp.Program.Multiply;

            // Act
            int multiplicationResult = multiplyDelegate(4, 6);

            // Assert
            Assert.AreEqual(expected, multiplicationResult);
        }

    }
}
