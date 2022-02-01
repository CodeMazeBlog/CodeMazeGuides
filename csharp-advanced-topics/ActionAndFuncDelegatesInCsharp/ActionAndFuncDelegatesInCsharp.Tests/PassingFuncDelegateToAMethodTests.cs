using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegatesInCsharp.Tests
{
    public class PassingFuncDelegateToAMethodTests
    {
        [Fact]
        public void AddExample_ShouldWork()
        {
            PassingFuncDelegateToAMethod passingFuncDelegateToAMethod = new PassingFuncDelegateToAMethod();
            int result = passingFuncDelegateToAMethod.RunAddExample();
            Assert.Equal(6, result);
        }
        [Fact]
        public void MultiplyExample_ShouldWork()
        {
            PassingFuncDelegateToAMethod passingFuncDelegateToAMethod = new PassingFuncDelegateToAMethod();
            int result = passingFuncDelegateToAMethod.RunMultiplyExample();
            Assert.Equal(8, result);
        }

    }
}
