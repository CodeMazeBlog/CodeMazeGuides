using ActionFuncInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Test_Delegate()
        {
            var log = new LogError(ErrorMessage);
            log("An error occured while testing");

            var invocationList = log.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }

        [TestMethod]
        public void Test_Action()
        {
            Action<string> LogError = ErrorMessage;
            LogError("An error occured while testing.");
            var invocationList = LogError.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }


        [TestMethod]
        public void Test_Func()
        {
            Func<string, string> greetings = GreetUser;
            string outcome = "Welcome back John. We are glad to see you";
            Assert.AreEqual(outcome , greetings("John"));
        }

        public static void ErrorMessage(string message)
        {
            Console.WriteLine($"Application down due to the following error: {message}");
        }
        public static string GreetUser(string user)
        {
            return $"Welcome back {user}. We are glad to see you";
        }
    }
}
