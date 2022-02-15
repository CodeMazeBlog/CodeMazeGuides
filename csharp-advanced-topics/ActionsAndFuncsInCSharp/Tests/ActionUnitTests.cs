using Xunit;
using ActionsAndFuncsInCSharp;

namespace Tests
{
    public class ActionUnitTests
    {
        [Fact]
        public void WhenCalled_ThenPrintMessage()
        {
            Assert.True(Actions.RunExample1());
            Assert.True(Actions.RunExample2());
            Assert.True(Actions.RunExample3());
            Assert.True(Actions.RunExample4());
            Assert.True(Actions.RunExample5());
            Assert.True(Actions.RunExample6());
        }
    }
}