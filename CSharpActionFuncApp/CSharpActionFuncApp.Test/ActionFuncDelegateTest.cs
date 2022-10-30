using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharpActionFuncApp.Test
{
    [TestClass]
    public class ActionFuncDelegateTest
    {
        private readonly DelegatesInAction _objDelegateInAction;

        public ActionFuncDelegateTest()
        {
            _objDelegateInAction = new DelegatesInAction();
        }

        [TestMethod]
        public void WhenCallingActionDelegateInAction_ThenNoException_ReturnsAddition()
        {
            try
            {
                int result = _objDelegateInAction.ActionDelegateInAction(10, 10);
                Assert.AreEqual(20, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void WhenCallingActionDelegateInActionUsingAnotherWay_ThenNoException_ReturnsAddition()
        {
            try
            {
                int result = _objDelegateInAction.ActionDelegateInActionUsingAnotherWay(10, 20);
                Assert.AreEqual(30, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        [TestMethod]
        public void WhenCallingFuncDelegateInAction_ThenNoException_ReturnsSum()
        {
            try
            {
                int result = _objDelegateInAction.FuncDelegateInAction(20, 20);
                Assert.AreEqual(40, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }


        [TestMethod]
        public void WhenCallingFuncDelegateInActionUsingAnotherWay_ThenNoException_ReturnsSum()
        {
            try
            {
                int result = _objDelegateInAction.FuncDelegateInActionUsingAnotherWay(20, 30);
                Assert.AreEqual(50, result);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}