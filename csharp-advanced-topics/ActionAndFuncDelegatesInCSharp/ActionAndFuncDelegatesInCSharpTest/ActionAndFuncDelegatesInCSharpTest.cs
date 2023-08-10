using ActionAndFuncDelegatesInCSharp;
using System.Diagnostics;
using System.Xml.Linq;
using static ActionAndFuncDelegatesInCSharp.DelegateService;
using static ActionAndFuncDelegatesInCSharp.FuncAndActionService;
namespace ActionAndFuncDelegatesInCSharpTest
{
    [TestClass]
    public class ActionAndFuncDelegatesInCSharpTest
    {
        [TestMethod]
        public void DelegateTestMethod()
        {
            var delegateService = new DelegateService();
            var d1 = new DelegateMethod(delegateService.DisplayResult);
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
            var result = 123;
            var action = new Action<int>(PrintValue);
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            action(123);

            var output = stringWriter.ToString();
            Assert.AreEqual($"{result}\r\n", output);
        }
    }
}