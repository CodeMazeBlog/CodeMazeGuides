using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static SampleDelegateConsoleApp.Program;

namespace Tests
{
    [TestClass]
    public class DelegateUnitTest
    {
        [TestMethod]
        public void Delegates_InvokingWithParameter_ResultsAsExpected()
        {
            var testSubject = new List<Tuple<MyDelegate, bool>>
            {
                new Tuple<MyDelegate, bool>(SevenElevenMethod, true),
                new Tuple<MyDelegate, bool>(FarmersMarketMethod, false),
            };

            string @param = "Buy milk";

            testSubject.ForEach(x =>
            {
                var result = x.Item1.Invoke(@param);
                Assert.AreEqual(x.Item2, result);
            });
        }

        [TestMethod]
        public void Funcs_InvokingWithParameter_ResultsAsExpected()
        {
            var testSubject = new List<Tuple<Func<string, bool>, bool>>
            {
                new Tuple<Func<string, bool>, bool>(SevenElevenMethod, false),
                new Tuple<Func<string, bool>, bool>(FarmersMarketMethod, true),
            };

            string @param = "Buy fresh milk";

            testSubject.ForEach(x =>
            {
                var result = x.Item1.Invoke(@param);
                Assert.AreEqual(x.Item2, result);
            });
        }

        [TestMethod]
        public void MulticastDelegate_AllInvoked_ExpectingResultFromLastItem()
        {
            var test = new MyDelegate(SevenElevenMethod) + new MyDelegate(FarmersMarketMethod);

            string @param = "Buy fresh milk";

            var result = test.Invoke(@param);

            Assert.IsTrue(result);
            Assert.AreEqual(2, test.GetInvocationList()?.Length);
        }

        [TestMethod]
        public void MulticastDelegateInReverseOrder_AllInvoked_ExpectingResultFromLastItem()
        {
            var test = new MyDelegate(FarmersMarketMethod) + new MyDelegate(SevenElevenMethod);

            string @param = "Buy fresh milk";

            var result = test.Invoke(@param);

            Assert.IsFalse(result);
            Assert.AreEqual(2, test.GetInvocationList()?.Length);
        }

        [TestMethod]
        public void MulticastFunc_AllInvoked_ExpectedFalseResultsExeptLastOne()
        {
            Func<string, bool> myFunc = SevenElevenMethod;

            myFunc += FarmersMarketMethod;

            myFunc += (string arg) => string.Compare("Testing Delegate Method", arg, true) == 0;

            string @param = "testing delegate method";

            var result = myFunc.Invoke(@param);

            Assert.IsTrue(result);

            var f = myFunc.GetInvocationList()[0];
            Assert.AreEqual(false, f.DynamicInvoke(@param));

            f = myFunc.GetInvocationList()[1];
            Assert.AreEqual(false, f.DynamicInvoke(@param));

            f = myFunc.GetInvocationList()[2];
            Assert.AreEqual(true, f.DynamicInvoke(@param));
        }
    }
}
