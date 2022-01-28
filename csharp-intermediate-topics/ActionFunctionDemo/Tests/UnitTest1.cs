using ActionFuncDemoInCSharp;
using System;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FuncDelegateTest()
        {
            Func<int, int, int> multiplyDelegate = Program.Multiply;
            Assert.Equal(10, multiplyDelegate(2, 5));
        }

        [Fact]
        public void ActionDelegateTest()
        {
            Action<string> writeDelegate = Program.DisplayName;
            var exception = Record.Exception(() => Program.DisplayName("Chriss"));
            Assert.Null(exception);
        }
    }
}
