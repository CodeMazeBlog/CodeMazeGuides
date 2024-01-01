using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void When_FuncAddingNumbers_Then_ReturnsCorrectSum() 
        {
            // Arrange
            Func<int, int, int> add = (x, y) => x + y;
            var expected = 8; // 5 + 3 = 8

            // Act
            var result = Program.AddNumbers(5, 3, add);

            // Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod()]
        public void When_PerformingAction_Then_ActionDelegateIsExecuted()
        {
            // Arrange
            var actionCalled = false;

            // Act
            Program.PerformAction(() => { actionCalled = true; });

            // Assert
            Assert.IsTrue(actionCalled);
        }
    }
}