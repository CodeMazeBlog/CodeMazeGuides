using Xunit;
using ActionsAndFuncsInCSharp;

namespace Tests
{
    public class FuncUnitTests
    {
        [Fact]
        public void WhenCalled_ThenGetTheMultipleValueOf2And4()
        {
            int result = Funcs.RunExample2();

            Assert.IsType<int>(result);
            Assert.Equal(2 * 4, result);
            Assert.NotEqual(2 + 4, result);
        }

        [Fact]
        public void WhenCalled_ThenGetTheMultipleValueOf4And4()
        {
            int result = Funcs.RunExample3();

            Assert.IsType<int>(result);
            Assert.Equal(4 * 4, result);
            Assert.NotEqual(4 + 4, result);
        }

        [Fact]
        public void WhenCalled_ThenGetTheMultipleValueOf6And4()
        {
            int result = Funcs.RunExample4();

            Assert.IsType<int>(result);
            Assert.Equal(6 * 4, result);
            Assert.NotEqual(6 + 4, result);
        }
    }
}