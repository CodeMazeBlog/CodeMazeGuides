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
        [Fact]
        public void GivenSentence_WhenExecuted_ThenSentenceOutputIsString()
        {
            actionDelegateClass.ActionDelegates();
            Assert.Contains(ActionDelegate.sentence, "I think. Therefore I am.");
        }
             
    }
}
