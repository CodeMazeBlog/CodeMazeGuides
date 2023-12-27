

namespace funcdelegateTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestFuncAddNumbers()
        {
            // Arrange
            Func<int, int, int> add = (x, y) => x + y;
            int expected = 8; // 5 + 3 = 8

            // Act
            int result = Program.AddNumbers(5, 3, add);

            // Assert
            Assert.Equal(expected, result);
        }
        [Fact]
        public void TestPerformAction()
        {
            // Arrange
            bool actionCalled = false;

            // Act
            Program.PerformAction(() => { actionCalled = true; });

            // Assert
            Assert.True(actionCalled);
        }
    }
}