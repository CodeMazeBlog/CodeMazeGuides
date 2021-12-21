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
        public void FuncDelegate_Sentence_ReturnsString()
            => Assert.Contains(_funcDelegate.FuncDelegates(), "1: I think. Therefore I am.");
        [Fact]
        public void MakeSentence_Sentence_ReturnsString()
            => Assert.Contains(_funcDelegate.MakeSentence("I think.", " Therefore I am"), "I think. Therefore I am.");
    }
}
