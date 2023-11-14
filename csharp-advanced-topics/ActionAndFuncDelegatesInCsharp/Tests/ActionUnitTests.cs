using ActionDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests
{
    [TestClass]
    public class ActionUnitTests
    {

        [TestMethod]
        public void Given_ActionSampleWithHelloMethod_When_ReceiveNameString_Then_SayHello()
        {
            Action<string> sayGreetings = ActionSample.Hello;
            var invocationList = sayGreetings.GetInvocationList();
            
            Assert.AreEqual(invocationList.Length, 1);
        }
        
        [TestMethod]
        public void Given_ActionSampleWithBonjureMethod_When_ReceiveNameString_Then_SayBonjure()
        {
            Action<string> sayGreetings = ActionSample.Bonjure;
            var invocationList = sayGreetings.GetInvocationList();
            
            Assert.AreEqual(invocationList.Length, 1);
        }
    }
}