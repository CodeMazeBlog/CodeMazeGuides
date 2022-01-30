using ActionAndFuncInCSharp;
using FluentAssertions;
using Moq;
using Xunit;

namespace ActionAndFuncInCharpTests
{
    public class ActionUsageTests
    {
        
        Mock<ExamplesForAction> _mockActionExamples;
        ExamplesForAction _examplesForAction;

        public ActionUsageTests()
        {
            _mockActionExamples = new Mock<ExamplesForAction>();
            _examplesForAction = _mockActionExamples.Object;
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
        public void Action_Should_RunMethod()
        {
            // Act
            _examplesForAction.ActionPointsToArgumentlessMethod();
            
            // Assert
            _mockActionExamples.Verify(s => s.Method());
        }

        [Fact]
        public void Action_Should_RunMethod_With_Params()
        {
            // Act
            _examplesForAction.ActionPointsToMethodWithArguments();

            // Assert
            _mockActionExamples.Verify(s => s.MethodWithParams(It.IsAny<int>()));
        }
    }
}