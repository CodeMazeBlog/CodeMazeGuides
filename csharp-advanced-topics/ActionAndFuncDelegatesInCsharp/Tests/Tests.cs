using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void TestActionDelegate()
        {
            // Arrange
            Action addDelegate = () => ActionAndFuncDelegatesInCsharp.Program.Add(5, 3);

            // Act
            addDelegate(); // Output: Addition Result: 8

            // Assert
            // The result is verified by inspecting the console output.
        }


        [TestMethod]
        public void TestFuncDelegate()
        {
            int expected = 24;
            // Arrange
            Func<int, int, int> multiplyDelegate = ActionAndFuncDelegatesInCsharp.Program.Multiply;

            // Act
            int multiplicationResult = multiplyDelegate(4, 6);

            // Assert
            Console.WriteLine($"Multiplication Result: {multiplicationResult}"); // Output: Multiplication Result: 24

            Assert.AreEqual(expected, multiplicationResult);
        }

    }
}
