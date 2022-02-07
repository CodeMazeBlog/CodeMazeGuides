using Xunit;
using FuncDelegateSample;

namespace Tests
{
    public class FuncTest
    {
        [Theory]
        [InlineData(20, 30)]
        public void WhenInvoked_ThenCallMultiplyFunction(int a, int b)
        {
            var result = new Program().InvokeMultiplication(a, b);

            Assert.IsType<int>(result);
            Assert.Equal(a * b, result);
        }

        [Theory]
        [InlineData(20, 30)]
        public void WhenCreatingShapes_ThenCalculateArea(int a, int b)
        {
            var result = new Shapes().ComputeArea();

            Assert.IsType<bool>(result);
            Assert.True(result);
        }
    }
}
