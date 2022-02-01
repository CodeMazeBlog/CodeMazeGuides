using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegatesInCsharp.Tests
{
    public class CallingAMethodWithAFuncDelegateTests
    {
        [Fact]
        public void WhenCallingMethodUsingFunc_ThenReturnFour()
        {
            CallingAMethodWithAFuncDelegate callingAMethodFromAFuncDelegate = new CallingAMethodWithAFuncDelegate();
            int result = callingAMethodFromAFuncDelegate.RunExample();

            Assert.Equal(4, result);
        }
    }
}
