using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegatesInCsharp.Tests
{
    public class CallingAMethodFromAFuncDelegateTests
    {
        [Fact]
        public void Example_ShouldWork()
        {
            CallingAMethodFromAFuncDelegate callingAMethodFromAFuncDelegate = new CallingAMethodFromAFuncDelegate();
            int result = callingAMethodFromAFuncDelegate.RunExample();
            Assert.Equal(4, result);
        }
    }
}
