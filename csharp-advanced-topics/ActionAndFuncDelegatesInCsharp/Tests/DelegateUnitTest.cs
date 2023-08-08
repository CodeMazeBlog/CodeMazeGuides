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

            // Act
            addDelegate(); // Output: Addition Result: 8

            // Assert
            // We can verify result by inspecting the Test Details Summary>Standard output.
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
