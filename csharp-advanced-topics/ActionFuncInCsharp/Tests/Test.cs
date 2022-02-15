using ActionFuncInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void whenStringIsSent_DelegateExecutesTheReferencedMethod()
        {
            var log = new logError(ErrorMessage);
            log("An error occured while testing");

            var invocationList = log.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }

        [TestMethod]
        public void whenStringIsSent_ActionDelegateExecutesTheReferencedMethod()
        {
            Action<string> logError = ErrorMessage;
            logError("An error occured while testing.");

            var invocationList = logError.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }

        [TestMethod]
        public void whenStringIsPassed_FuncDelegateReturnsBackGreeting()
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
