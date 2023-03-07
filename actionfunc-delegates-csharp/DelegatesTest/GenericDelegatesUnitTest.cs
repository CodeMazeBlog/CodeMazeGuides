using ActionFuncDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DelegatesTest
{
    [TestClass]
    public class GenericDelegatesUnitTest
    {
        [TestMethod]
        public void FuncDelegate_ExpectedResult()
        {
            // Arrange
            Solution solution = new Solution();

            // Act
            int result = solution.FuncHandler(50, 60);

            // Assert
            Assert.AreEqual("The sum of 50 and 60 is 110", result);
        }

        [TestMethod]
        public void ActionDelegate_ExpectedAction()
        {
            // Arrange
            Solution solution = new Solution();

            // Act
            solution.ActionHandler(78);


            // Assert
            Assert.IsTrue(solution.isActionCalled);
        }
    }
}
