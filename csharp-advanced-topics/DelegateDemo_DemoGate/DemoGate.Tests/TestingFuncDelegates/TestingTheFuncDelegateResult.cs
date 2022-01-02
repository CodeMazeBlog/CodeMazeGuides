using System;
using System.Collections.Generic;
using System.Text;
using DelegateDemo_DemoGate;
using Xunit;

namespace DemoGate.Tests.TestingFuncDelegates
{
    public class TestingTheFuncDelegateResult
    {
        private readonly FuncDelegate _funcDelegate;
        public TestingTheFuncDelegateResult() => _funcDelegate = new FuncDelegate();
        [Fact]
        public void GivenFuncDelegate_WhenExecuted_ThenReturnString()
            => Assert.Contains(_funcDelegate.FuncDelegates(), "1: I think. Therefore I am.");
        [Fact]
        public void GivenMakeSentenceMethod_WhenExecuted_ThenReturnString()
            => Assert.Contains(_funcDelegate.MakeSentence("I think.", " Therefore I am"), "I think. Therefore I am.");
    }
}
