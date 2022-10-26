using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpActionFuncApp;
namespace CSharpActionFuncApp.Test
{
    [TestClass]
    public class ActionFuncDelegateTest
    {
        readonly DelegatesInAction objDelegateInAction;

        public ActionFuncDelegateTest()
        {
            objDelegateInAction = new DelegatesInAction();
        }

        [TestMethod]
        public void WhenCallingActionDelegateInAction_ThenNoException()
        {
            try
            {
                objDelegateInAction.ActionDelegateInAction();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WhenCallingFuncDelegateInAction_ThenNoException()
        {
            try
            {
                objDelegateInAction.FuncDelegateInAction();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

    }
}