using ActionFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class DelegatesTest
    {
        [TestMethod]
        public void Delegate_WhenAddOperation_ThenOutputForAdd()
        {
            int a = 6;
            int b = 3;
            int result = 9;

            Assert.AreEqual(result, DelegatesDemo.Calculate(a, b, MathOperation.Add));

        }
        [TestMethod]
        public void Delegate_WhenSubtractOperation_ThenOutputForSubtract()
        {
            int a = 6;
            int b = 3;
            int result = 3;

            Assert.AreEqual(result, DelegatesDemo.Calculate(a, b, MathOperation.Subtract));

        }
        [TestMethod]
        public void Delegate_WhenMultiplyOperation_ThenOutputForMultiply()
        {
            int a = 6;
            int b = 3;
            int result = 18;

            Assert.AreEqual(result, DelegatesDemo.Calculate(a, b, MathOperation.Multiply));

        }
        [TestMethod]
        public void Delegate_WhenDivideOperation_ThenOutputForDivide()
        {
            int a = 6;
            int b = 3;
            int result = 2;

            Assert.AreEqual(result, DelegatesDemo.Calculate(a, b, MathOperation.Divide));

        }
    }
}
