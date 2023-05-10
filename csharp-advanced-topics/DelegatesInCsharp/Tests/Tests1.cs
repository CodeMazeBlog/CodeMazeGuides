using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests1
    {
        delegate double MathCalculation(float value1, float value2);
        public static double AddNums(float value1, float value2) => value1 + value2;
        public static double DivideNums(float value1, float value2) => value1 / value2;
        public static void DemonstrateActionDelegate(string str) => Console.WriteLine(str);

        [TestMethod]
        public void Demonstrate_DelegateWithInvoke()
        {
            var delegate1 = new MathCalculation(AddNums);
            var result = delegate1.Invoke(100, 3);
            Assert.AreEqual(AddNums(100, 3), result);
        }
        [TestMethod]
        public void Demonstrate_DelegateWithoutInvoke()
        {
            var delegate1 = new MathCalculation(DivideNums);
            var result = delegate1(100, 3);
            Assert.AreEqual(DivideNums(100, 3), result);
        }
        [TestMethod]
        public void Demonstrate_ActionDelegate()
        {
            Action<string> executeActionDelegate = DemonstrateActionDelegate;
            var list = executeActionDelegate.GetInvocationList();
            Assert.AreEqual(list.Length, 1);
        }
        [TestMethod]
        public void Demonstrate_FuncDelegate()
        {
            Func<float, float, double> executeFuncDelegate = AddNums;
            var list = executeFuncDelegate.GetInvocationList();
            Assert.AreEqual(list.Length, 1);
        }
    }
}
