using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class ActionDelegateUnitTest
    {
        [TestMethod]
        public void GivenTwoNumbers_ThenResultMultiplication()
        {
            int num1 = 2, num2 = 3;

            Func<int, int, int> Multiply = Multiplication;

            Assert.AreEqual(6, Multiply(num1,num2));
        }
        public static int Multiplication(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}