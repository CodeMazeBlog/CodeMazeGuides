using ActionAndFuncDelegates;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncUnitTest
    {
        private Methods _methods;

        [TestInitialize]
        public void Setup()
        {
            _methods = new Methods();
        }

        [TestMethod]
        public void WhenInvokingDelegate_ThenMethodCalled()
        {
            var delegateInstance = new Delegates.AddDelegate(_methods.Adder);

            Assert.AreEqual(5, delegateInstance.Invoke(2, 3));
            Assert.AreEqual(5, delegateInstance(2, 3));
        }
        
        [TestMethod]
        public void WhenInvokingGenericDelegate_ThenMethodCalled()
        {
            var genericDelegateInstance = new Delegates.AddGenericDelegate<int, int, int>(_methods.Adder);

            Assert.AreEqual(5, genericDelegateInstance(2, 3));
        }

        [TestMethod]
        public void WhenInvokingFunc_ThenMethodCalled()
        {
            var funcInstance = new Func<int, int, int>(_methods.Adder);

            Assert.AreEqual(5, funcInstance(2, 3));
        }

        [TestMethod]
        public void WhenInvokingAction_ThenMethodCalled()
        {
            var actionInstance = new Action<string>(_methods.Logger);
            
            actionInstance("some error message");
            
            Assert.IsTrue(_methods.LoggerCalled);
        }
    }
}