using ActionDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests
{
    [TestClass]
    public class ActionUnitTests
    {

        [TestMethod]
        public void GivenActionSampleWithHelloMethod_WhenReceiveNameString_ThenSayHello()
        {
            Action<string> sayGreetings = ActionSample.Hello;
            var invocationList = sayGreetings.GetInvocationList();
            
            Assert.AreEqual(invocationList.Length, 1);
        }
        
        [TestMethod]
        public void GivenActionSampleWithBonjureMethod_WhenReceiveNameString_ThenSayBonjure()
        {
            Action<string> sayGreetings = ActionSample.Bonjure;
            var invocationList = sayGreetings.GetInvocationList();
            
            Assert.AreEqual(invocationList.Length, 1);
        }
    }
}