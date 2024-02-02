using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Action_Func_TestUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Func<int, int, int> sumFunc = (a, b) => a + b; int result = sumFunc(3, 4); // result = 7

            Action<int, int> ActionCalculator = (a, b) =>
            {
                Console.WriteLine($"Addition result: {a + b}");
                Console.WriteLine($"Subtraction result: {a - b}");
                Console.WriteLine($"Multiplication result: {a * b}");
                Console.WriteLine($"Division result: {a / b}");
            };

            ActionCalculator(9, 3);
        }
    }
}
