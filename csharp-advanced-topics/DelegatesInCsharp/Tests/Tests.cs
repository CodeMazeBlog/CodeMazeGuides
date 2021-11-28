using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    public delegate int FirstOperationDelegate(int a, int b);

   

    [TestClass]
	public class Tests
    {
        static FirstOperationDelegate dt;
        static string resultFuncDelegate = string.Empty;
        public static string _ResultTestAction { get; private set; }

        [TestMethod]
        public void testDelegate()
        {
            dt = new FirstOperationDelegate(Adding);
            Assert.AreEqual(10, F(dt));
        }

        [TestMethod]
        public void testFunc()
        {
            Func<int, int, int> addingFuncOperation = AddingFunc;
            Assert.AreEqual(5, addingFuncOperation(2, 3));
        }

        [TestMethod]
        public void testAction()
        {
            Action<string, int> action = new Action<string, int>(DisplayNameAndAge);
            action("Ann", 15);
            Assert.AreEqual(_ResultTestAction, "The username is Ann and the age is 15.");
        }

        public static int F(FirstOperationDelegate myFunc)
        {
           return myFunc(8,2);
        }

        public static int Adding(int a, int b)
        {
           return a + b;
        }

        static void DisplayNameAndAge(string username, int age)
        {
            _ResultTestAction = $"The username is {username} and the age is {age}.";
        }

        public static int AddingFunc(int a, int b)
        {
            return a + b;
        }
    }
}
