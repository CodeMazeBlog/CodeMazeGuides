using ActionAndFuncDelegatesInCSharp.Action;
using ActionAndFuncDelegatesInCSharp.CustomDelegate;
using ActionAndFuncDelegatesInCSharp.Func;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace ActionAndFuncDelegatesInCSharpTest
{
    public class ActionAndFuncDelegatesInCSharpTest
    {
        [Fact]
        public void WhenFuncDelegateUsed_ThenCheckTheStringsAreEqual()
        {
            string returnString = FuncMethod.GetValueFromFunc();
            Assert.Equal("I Love C# using Func", returnString);
        }

        [Fact]
        public void WhenFuncDelegateLambdaUsed_ThenCheckTheStringsAreEqual()
        {
            string returnString = FuncMethod.GetValueFromFuncLambda();
            Assert.Equal("I Love C# using Func with Lambda Expression", returnString);
        }

        [Fact]
        public void WhenActionDelegateUsed_ThenCheckTheStringsAreEqual()
        {
            try
            {
                ActionMethod.GetValueFromAction();
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public void WhenActionDelegateLambdaUsed_ThenCheckTheStringsAreEqual()
        {
            try
            {
                ActionMethod.GetValueFromActionLambda();
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public void WhenCustomDelegateUsed_ThenCheckTheStringsAreEqual()
        {
            string returnString = CustomDelegate.GetValueFromCustomDelegate();
            Assert.Equal("I Love C# with Custom Delegates", returnString);
        }
    }
}