using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesTest
{
    [TestClass]
    public class DelegatesTest
    {
        public delegate void MyDelegate(string message);
        [TestMethod]
        public void whenStringIsSent_DelegateExecutesReferenceMethods()
        {
            //test for a simple delegate with message;
            MyDelegate myDelegate = MyGreeting.whenStringIsSent_DelegateReferenceMethod;
            myDelegate("Good Morning to you.");


            //Working of an action delegate.
            //declare and use an action delegate here.  
            ForActionDelegate_whenTwoParametersAreSent();

            //Working of a Func Delegate.
            //declare and use a func delegate with 2 input and one out parameter.
            ForFuncDelegate_whenTwoParametersAreSent();
      
        }
        [TestMethod]
        public void ForActionDelegate_whenTwoParametersAreSent()
        {
            var x = 20;
            var y = 5;
            var result = x-y;
            Action<int, int> val = delegate (int x, int y)
            {
                Console.WriteLine("Action Delegate implemented- Output " + (x - y));
            };
            val(x , y);
            var sub = 15;
            Assert.AreEqual(sub, result);
        }
       
        [TestMethod]
        public static void ForFuncDelegate_whenTwoParametersAreSent()
        {
            var a = 10;
            var b = 20;
            Func<int, int, int> SumDelegate = delegate (int x, int y)
            {
                return x + y;
            };
            SumDelegate(10, 20);
            Assert.AreEqual(30, a + b);
        }
    }
    [TestClass]
    public class MyGreeting
    {
        [TestMethod]
        public static void whenStringIsSent_DelegateReferenceMethod(string Msg)
        {
            Console.WriteLine("This is my greeting " + Msg);
            Assert.AreEqual("Good Morning to you.", Msg);

        }
    }
}
