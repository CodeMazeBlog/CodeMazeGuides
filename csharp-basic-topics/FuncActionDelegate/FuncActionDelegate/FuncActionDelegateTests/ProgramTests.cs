using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void TestFuncAddNumbers()
        {
            // Arrange
            Func<int, int, int> add = (x, y) => x + y;
            int expected = 8; // 5 + 3 = 8

            // Act
            int result = Program.AddNumbers(5, 3, add);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod()]
        public void TestPerformAction()
        {
            // Arrange
            bool actionCalled = false;

            // Act
            Program.PerformAction(() => { actionCalled = true; });

            // Assert
            Assert.IsTrue(actionCalled);
        }
    }
}