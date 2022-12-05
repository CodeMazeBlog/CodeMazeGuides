using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionAndFuncDelegate;

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
       
    }
}