using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tests
{
    [TestClass]
    public class ActionDelegateUnitTest
    {
        [TestMethod]
        public void WhenUsingFuncDelegateOnMultiplication_DelegateExecutesMultiplication()
        {
            int num1 = 2, num2 = 3;
            int Multiplication(int num1, int num2)
            {
                return num1 * num2;
            }

            Func<int, int, int> Multiply = Multiplication;

            Assert.AreEqual(6, Multiply(num1, num2));
        }


        [TestMethod]
        public void WhenUsingActionDelegateOnConsolePrintNumber_DelegateExecutesConsolePrintNumber()
        {
            using (var stringWriter = new StringWriter())
            {
                int num = 4;
                Console.SetOut(stringWriter);

                void ConsolePrintNumber(int number)
                {
                    Console.WriteLine(number);
                }

                Action<int> PrintNumber = ConsolePrintNumber;
                PrintNumber(num);

                Assert.IsTrue(stringWriter.ToString().Contains("4"));
            }

        }
    }
}