using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegatesInCsharp.Tests
{
    public class FuncWithAnAnonymousMethodTests
    {
        [Fact]
        public void Example_ShouldWork()
        {
            FuncWithAnAnonymousMethod funcWithAnAnonymousMethod = new FuncWithAnAnonymousMethod();
            int result = funcWithAnAnonymousMethod.RunExample();
            Assert.IsType<int>(result);
        }

    }
}
