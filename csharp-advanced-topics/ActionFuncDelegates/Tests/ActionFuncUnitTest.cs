using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tests
{
    [TestClass]
    public class ActionFuncUnitTest
    {
        [TestMethod]
        public void WhenUsingActionWithNamedMethod_ThenActionExecutesNamedMethod()
        {
            using (StringWriter stringWriter = new())
            {
                Console.SetOut(stringWriter);

                void Greeting(string username)
                {
                    Console.WriteLine($"Hello, { username }!");
                }

                Action<string> greetUser = Greeting;
                greetUser("George");

                Assert.IsTrue(stringWriter.ToString().Contains("Hello, George!"));
            }
        }

        [TestMethod]
        public void WhenUsingFuncWithAnonymousMethod_ThenFuncExecutesAnonymousMethod()
        {
            // The third double in Func<double, double, double> is the output
            Func<double, double, double> add = delegate (double firstNumber, double secondNumber)
            {
                return firstNumber + secondNumber;
            };

            add(6, 7.5);

            Assert.AreEqual(add(6, 7.5), (6 + 7.5));
        }

        [TestMethod]
        public void WhenUsingFuncWithLambdaExpression_ThenFuncExecutesLambdaExpression()
        {
            // The third double in Func<double, double, double> is the output
            Func<double, double, double> multiply = (double firstNumber, double secondNumber) => firstNumber * secondNumber;

            multiply(6, 7.5);

            Assert.AreEqual(multiply(6, 7.5), (6 * 7.5));
        }
    }
}