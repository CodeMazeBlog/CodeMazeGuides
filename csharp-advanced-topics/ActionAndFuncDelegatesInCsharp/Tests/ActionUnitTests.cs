using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Tests
{
    [TestClass]
    public class ActionUnitTests
    {
        public static void Hello(string name)
        {
            Console.WriteLine($"Hello, {name}");
        }

        public static void Bonjure(string name)
        {
            Console.WriteLine($"Bonjure, {name}");
        }
        
        [TestMethod]
        public void WhenRecieveNameString_SayHello()
        {
            Action<string> sayGreetings = Hello;
            var invocationList = sayGreetings.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }
        
        [TestMethod]
        public void WhenRecieveNameString_SayBonjure()
        {
            Action<string> sayGreetings = Bonjure;
            var invocationList = sayGreetings.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }
    }
}