using ActionFuncDelegatesInCSharp;
using System;
using Xunit;

namespace Tests
{
    public class ActionUnitTest
    {
        Action action = Program.TestMethod;
        Action<int> actionGeneric = Program.TestMethod;

        [Fact]
        public void GivenActionDelegate_InvocationListNameEqualsMethodName()
        {
            var actionMethod = action.GetInvocationList();
            Assert.Equal("TestMethod", actionMethod[0].Method.Name);
        }

        [Fact]
        public void GivenActionDelegate_InvocationListHasAMethod()
        {
            var actionMethod = action.GetInvocationList();
            Assert.Single(actionMethod);
        }

        [Fact]
        public void whenGenericActionDelegate_DelegateExecutesTheMatchingReferenceMethod()
        {
            actionGeneric(10);
            Assert.NotNull(actionGeneric);
        }
    }
}
