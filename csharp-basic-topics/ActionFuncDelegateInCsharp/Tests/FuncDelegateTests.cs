using ActionFuncDelegateInCsharp;

namespace Tests
{
    public class FuncDelegateTests
    {
        [Fact]
        public void GivenTwoNumbers_ThenShouldBeAdded()
        {
            // Act
            var result = FuncDelegate.AddNumbers(5, 7);

            // Assert
            Assert.Equal(12, result);
        }

        [Fact]
        public void GivenTwoNegativeNumbers_ThenShouldBeAdded()
        {
            // Act
            var result = FuncDelegate.AddNumbers(-3, -5);

            // Assert
            Assert.Equal(-8, result);
        }
    }
}
