using Delegation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests1
    {
        delegate double MathCalculation(float value1, float value2);

        [TestMethod]
        public void Demonstrate_DelegateWithInvoke()
        {
            var methods = new GenericMethods();
            var delegate1 = new MathCalculation(methods.Addition);
            var result = delegate1.Invoke(100, 3);
            Assert.AreEqual(methods.Addition(100, 3), result);
        }
        [TestMethod]
        public void Demonstrate_DelegateWithoutInvoke()
        {
            var methods = new GenericMethods();
            var delegate1 = new MathCalculation(methods.Multiplication);
            var result = delegate1(100, 3);
            Assert.AreEqual(methods.Multiplication(100, 3), result);
        }
        [TestMethod]
        public void Demonstrate_ActionDelegate()
        {
            var methods = new GenericMethods();
            Action<string> executeActionDelegate = methods.PrintString;
            var list = executeActionDelegate.GetInvocationList();
            Assert.AreEqual(list.Length, 1);
        }
        [TestMethod]
        public void Demonstrate_FuncDelegate()
        {
            var methods = new GenericMethods();
            Func<float, float, double> executeFuncDelegate = methods.Multiplication;
            var list = executeFuncDelegate.GetInvocationList();
            Assert.AreEqual(list.Length, 1);
        }
    }
}
