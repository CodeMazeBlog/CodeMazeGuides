using ActionAndFuncInCSharp;
using FluentAssertions;
using Moq;
using Xunit;

namespace ActionAndFuncInCharpTests
{
    public class FuncUsageTests
    {
        Mock<ExamplesForFunc> _mockFuncExamples;
        ExamplesForFunc _examplesForFunc;

        public FuncUsageTests()
        {
            _mockFuncExamples = new Mock<ExamplesForFunc>();
            _examplesForFunc = _mockFuncExamples.Object;
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
        public void Func_Should_RunMethod()
        {
            // Act
            _examplesForFunc.FuncPointsToArgumentlessMethod();

            // Assert
            _mockFuncExamples.Verify(s => s.Method());
        }

        [Fact]
        public void Func_Should_RunMethod_With_Params()
        {
            // Act
            _examplesForFunc.FuncPointsToMethodWithArguments();

            // Assert
            _mockFuncExamples.Verify(s => s.MethodWithParams(It.IsAny<int>()));
        }

        [Fact]
        public async Task Func_Should_RunAsyncMethod()
        {
            // Act
            await _examplesForFunc.FuncPointsToAsyncMethod();

            // Assert
            _mockFuncExamples.Verify(s => s.MethodAsync());
        }
    }
}