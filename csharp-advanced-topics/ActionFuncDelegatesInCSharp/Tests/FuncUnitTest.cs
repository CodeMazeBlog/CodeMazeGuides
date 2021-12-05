using ActionFuncDelegatesInCSharp;
using System;
using Xunit;

namespace Tests
{
    public class FuncUnitTest
    {
        Func<int> func = Program.FuncMethod;
        Func<int, int, int> funcGeneric = Program.FuncMethod;

        [Fact]
        public void GivenFuncDelegate_InvocationListNameEqualsMethodName()
        {
            var funcMethod = func.GetInvocationList();
            Assert.Equal("FuncMethod", funcMethod[0].Method.Name);
        }

        [Fact]
        public void GivenFuncDelegate_InvocationListHasAMethod()
        {
            var funcMethod = func.GetInvocationList();
            Assert.Single(funcMethod);
        }

        [Fact]
        public void GivenFuncDelegateWithoutParameters_DelegateExecutesTheMatchingReferenceMethod()
        {
            var result = func();
            Assert.Equal(50, result);
        }

        [Fact]
        public void GivenFuncDelegateWithParameters_DelegateExecutesTheMatchingReferenceMethod()
        {
            var result = funcGeneric(100, 5);
            Assert.Equal(20, result);
        }
        
    }
}
