using ActionAndFuncDelegatesInCSharp;
using static ActionAndFuncDelegatesInCSharp.DelegateService;
using static ActionAndFuncDelegatesInCSharp.FuncAndActionService;
namespace ActionAndFuncDelegatesInCSharpTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DelegateTestMethod()
        {
            DelegateService delegateService = new DelegateService();
            DelegateMethod d1 = new DelegateMethod(delegateService.DisplayResult);
            Assert.AreEqual(8, d1(3, 5));
        }

        [TestMethod]
        public void FuncTestMethod()
        {
            var func = new Func<int, int, int>(CalculateValue);
            var funcResult = func(2, 5);
            Console.WriteLine($"Func method result: {funcResult}");
            Assert.AreEqual(10, funcResult);
        }

        [TestMethod]
        public void ActionTestMethod()
        {
            var action = new Action<int>(PrintValue);

            try
            {
                action(123);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}