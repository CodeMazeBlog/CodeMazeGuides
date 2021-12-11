using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoSomethingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoSomethingLibrary.Tests
{
    [TestClass()]
    public class DoSomethingTests
    {
        [TestMethod()]
        public void whenActionIsPassed_ShouldCallIt()
        {
            var actionCalled = false;
            Action testAction = () =>
            {
                actionCalled = true;
            };

            DoSomething.LongProcess(testAction);

            Assert.IsTrue(actionCalled);
        }

        [TestMethod()]
        public void whenActionWithParameterIsPassed_ShouldCallIt()
        {
            var actionCalled = false;
            var parameterSent = 0;
            Action<int> testAction = (x) =>
            {
                actionCalled = true;
                parameterSent = x;
            };

            DoSomething.LongProcess(testAction);

            Assert.IsTrue(actionCalled);
            Assert.IsTrue(parameterSent > 0);
        }

        [TestMethod()]
        public void whenFuncIsPassed_ShouldCallIt()
        {
            var funcCalled = false;
            
            Func<bool> testFunc = () =>
            {
                funcCalled = true;
                return false;
            };

            DoSomething.InteractiveProcess(testFunc);

            Assert.IsTrue(funcCalled);
        }

        [TestMethod()]
        public void whenFuncWithParameterIsPassed_ShouldCallIt()
        {
            var funcCalled = false;
            var parameterSent = 0;

            Func<int,bool> testFunc = (x) =>
            {
                parameterSent = x;
                funcCalled = true;
                return false;
            };

            DoSomething.InteractiveProcess(testFunc);

            Assert.IsTrue(funcCalled);
            Assert.IsTrue(parameterSent > 0);
        }

    }
}

namespace DoSomethingLibraryTests
{
    internal class DoSomethingTests
    {
    }
}
