using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void WhenUsingActionDelegateOnNamedMethod_DelegateExecutesNamedMethod()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                void Greeting(string name)
                {
                    Console.WriteLine($"Hello {name}!");
                }

                Action<string> method = Greeting;
                method("John");

                Assert.IsTrue(stringWriter.ToString().Contains("Hello John!"));
            }
        }

        [TestMethod]
        public void WhenUsingFuncDelegate_DelegateExecutesNamedMethod()
        {
            string GetDateString()
            {
                return DateTime.Today.ToShortDateString();
            }

            // Stores a method that takes no parameter and returns a string
            Func<string> func = GetDateString;
            Assert.AreEqual(DateTime.Today.ToShortDateString(), func());
        }

        [TestMethod]
        public void WhenInitializingFuncDelegateWithDelegateExpression_DelegateExpressionGetsExecuted()
        {
            Func<string> dayNamed = delegate ()
            {
                return DateTime.Today.ToString("dddd");
            };

            Assert.AreEqual(DateTime.Today.ToString("dddd"), dayNamed());
        }

        [TestMethod]
        public void WhenInitializingFuncDelegateWithLambdaExpression_DelegateExpressionGetsExecuted()
        {
            Func<string> dayLambda = () => DateTime.Today.ToString("dddd");
            Assert.AreEqual(DateTime.Today.ToString("dddd"), dayLambda());
        }

        [TestMethod]
        public void WhenUsingDelegateAsMethodParameter_MethodUsesLambdaExpresion()
        {
            long ProcessNumberSeries(
                long[] series,
                Func<long, long, long> operation)
            {
                var accum = 0L;
                foreach (var item in series)
                    accum = operation(accum, item);

                return accum;
            }

            var series = new long[] { 1, 5, 6, 9 };

            Assert.AreEqual(1 + 5 + 6 + 9, ProcessNumberSeries(series, (acc, item) => acc + item));
            Assert.AreEqual(1 * 5 * 6 * 9, ProcessNumberSeries(series, (acc, item) => acc == 0 ? item : acc * item));
        }
    }
}