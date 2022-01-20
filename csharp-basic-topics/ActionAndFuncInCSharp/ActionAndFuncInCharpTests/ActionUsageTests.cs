using FluentAssertions;
using Xunit;

namespace ActionAndFuncInCharpTests
{
    public class ActionAndFuncUsageTests
    {
        void TestActionMethod()
        {
            throw new Exception("method error message");
        }

        int TestFuncMethod()
        {
            return 2;
        }

        [Fact]
        public void Action_Should_RunLambda()
        {
            // Arrange
            var action = () => { throw new Exception("error message"); };

            // Act && Assert
            action.Should().Throw<Exception>("error message");
        }

        [Fact]
        public void Func_Should_RunLambda()
        {
            // Arrange
            Func<int> func = () => { return 1; };
            var expected = 1;

            // Act
            var actual = func();

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public void Action_Should_RunMethod()
        {
            // Arrange
            var action = TestActionMethod;

            // Act && Assert
            action.Should().Throw<Exception>("error message");
        }

        [Fact]
        public void Func_Should_RunMethod()
        {
            // Arrange
            Func<int> func = TestFuncMethod;
            
            var expected = 2;

            // Act
            var actual = func();

            // Assert
            actual.Should().Be(expected);
        }
    }
}