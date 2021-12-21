using DelegateDemo_DemoGate;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DemoGate.Tests.TestingActionDelegates
{
    public class TestingTheActionDelegatesResults
    {
        ActionDelegate actionDelegateClass = new ActionDelegate();
        //public TestingTheActionDelegatesResults() => _actionDelegate = new ActionDelegate();
        [Fact]
        public void ActionDelegate_Sentence_ReturnsString()
        {
            actionDelegateClass.ActionDelegates();
            Assert.Contains(ActionDelegate.sentence, "I think. Therefore I am.");
        }
             
    }
}
