using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuncAndActionDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegates.Tests
{
    [TestClass()]
    public class Tests
    {
        [TestMethod()]
        public void GivenFuncDelegate_WhenMethodReferenced_DelegateInvokationListNotEmpty()
        {
            Func<int, int, int> funcDel = Program.AddNumbers;
            var invokationList = funcDel.GetInvocationList();
            Assert.IsNotNull(invokationList);
            Assert.AreEqual(1, invokationList.Length);
        }

        [TestMethod()]
        public void GivenFuncDelegate_WhenMethodReferenced_DelegateExecutesTheReferencedMethod()
        {
            Func<int, int, int> funcDel = Program.AddNumbers;
            var result = funcDel(4, 8);
            Assert.AreEqual(12, result);
        }

        [TestMethod()]
        public void GivenActionDelegate_WhenParameterlessMethodReferenced_DelegateInvokationListNotEmpty()
        {
            Action actionDel = Program.PrintMessage;
            var invokationList = actionDel.GetInvocationList();
            Assert.IsNotNull(invokationList);
            Assert.AreEqual(1, invokationList.Length);
        }

        [TestMethod()]
        public void GivenActionDelegate_WhenParameterizedMethodReferenced_DelegateInvokationListNotEmpty()
        {
            Action<string, string> actionDel = Program.PrintFullName;
            var invokationList = actionDel.GetInvocationList();
            Assert.IsNotNull(invokationList);
            Assert.AreEqual(1, invokationList.Length);
        }
    }
}
