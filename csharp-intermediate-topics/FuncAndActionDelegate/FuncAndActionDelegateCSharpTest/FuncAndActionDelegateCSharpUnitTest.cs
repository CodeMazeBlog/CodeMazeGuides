using FuncAndActionDelegateCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuncAndActionDelegateCSharpUnitTestNamespace
{
    [TestClass]
    public class FuncAndActionDelegateCSharpUnitTest
    {
        [TestMethod]
        public void WhenCallFuncDelegate_ThenPrintMessage(){ 
            DelegateClass delegateClass = new DelegateClass();
            string message = delegateClass.WelcomeMessageFuncDelegate("World");

            Assert.AreEqual("Hello World", message);
        }

        [TestMethod]
        public void WhenCallActionDelegate_ThenPrintMessage(){
            DelegateClass delegateClass = new DelegateClass();
            delegateClass.WelcomeMessageActionDelegate("World");

            Assert.AreEqual("Hello World", delegateClass.Message);
        }
    }
}