using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionAndFuncDelegate;
using System.Text;

namespace Tests
{
    [TestClass]
    public class ActionFuncDelegateUnitTest
    {
        //Func delegate
        Func<int, int, int>? AddFuncDelegate = new Func<int, int, int>(BasicMaths.Add);
        Func<int, int, int>? SubFuncDelegate = new Func<int, int, int>(BasicMaths.Sub);

        //Action delegate
        Action<int> ActionDelegateEvenOrOdd = new Action<int>(BasicMaths.EvenOrOdd);
        Action<double, double> ActionDelegateMaximum = new Action<double, double>(BasicMaths.Maximum);

        //Func delegate Test Methods
        [TestMethod]
        public void WhenAddFuncDelegateCalled_ThenAddMethodAddTwoNumbers()
        {
            int result = AddFuncDelegate(50, 5);

            Assert.AreEqual(result, 55);
        }

        [TestMethod]
        public void WhenSubFuncDelegateCalled_ThenSubMethodSubstractTwoNumbers()
        {
            int result = SubFuncDelegate(50, 5);

            Assert.AreEqual(result, 45);
        }

        //Action delegate Test Methods
        [TestMethod]
        public void WhenEvenOddActionCalled_ThenPrintNumberIsEvenOrOdd()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ActionDelegateEvenOrOdd(50);
                var result = sw.ToString().Trim();
                string expected = "50 is even number.";

                Assert.AreEqual(expected, result);

            }
        }

        [TestMethod]
        public void WhenMaximumNumberActionCalled_ThenPrintMaximumOfTwoNumber()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ActionDelegateMaximum(45, 55);
                var result = sw.ToString().Trim();
                string expected = "Maximum of 45 and 55 is 55.";

                Assert.AreEqual<string>(expected, result);
            }
        }

    }
}