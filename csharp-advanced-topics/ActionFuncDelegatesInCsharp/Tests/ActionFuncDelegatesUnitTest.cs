using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionFuncDelegatesInCsharp;
using System;
using System.IO;

namespace Tests
{
    [TestClass]
    public class ActionFuncDelegatesUnitTest
    {
        [TestMethod]
        public void whenMultiplyTwoNumbers_thenCorrrectProduct()
        {
            int first = 10;
            int second = 12;
            int expected = 120;

            //call the method to calculate the product of two numbers
            int actual = ActionFuncDelegates.Multiply(first, second);

            //check whether the expected and actual values are equal
            Assert.AreEqual(expected, actual, "passed");
        }
        [TestMethod]
        public void whenMultiplyTwoNumbersWithAnonymous_thenCorrrectProduct()
        {
            int first = 10;
            int second = 12;
            int expected = 120;

            //call the method to calculate the product of two numbers
            int actual = ActionFuncDelegates.MultiplyFuncAnonymous(first, second);

            //check whether the expected and actual values are equal
            Assert.AreEqual(expected, actual, "passed");
        }
        [TestMethod]
        public void whenMultiplyTwoNumbersWithLambda_thenCorrrectProduct()
        {
            int first = 10;
            int second = 12;
            int expected = 120;

            //call the method to calculate the product of two numbers
            int actual = ActionFuncDelegates.MultiplyFuncLambda(first, second);

            //check whether the expected and actual values are equal
            Assert.AreEqual(expected, actual, "passed");
        }

        [TestMethod]
        public void whenInputString_thenCorrrectWelcomeMassage()
        {
            string name = "John";
            string expected = "Welcome, John";

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                ActionFuncDelegates.Welcome(name);

                StringAssert.Contains(Convert.ToString(stringWriter), expected);
            }
        }
        [TestMethod]
        public void whenInputStringWithAnonymous_thenCorrrectWelcomeMassage()
        {
            string name = "John";
            string expected = "Welcome, John";

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                ActionFuncDelegates.WelcomeAnonymous(name);

                StringAssert.Contains(Convert.ToString(stringWriter),expected);
            }
        }
        [TestMethod]
        public void whenInputStringWithLambda_thenCorrrectWelcomeMassage()
        {
            string name = "John";
            string expected = "Welcome, John";

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                ActionFuncDelegates.WelcomeLambda(name);

                StringAssert.Contains(Convert.ToString(stringWriter), expected);
            }
        }
    }
}