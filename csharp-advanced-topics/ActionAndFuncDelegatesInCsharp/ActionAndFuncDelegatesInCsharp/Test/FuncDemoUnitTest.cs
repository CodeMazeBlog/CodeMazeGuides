using ActionAndFuncDelegatesInCsharp;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Test
{
    [TestClass]
    public class FuncDemoUnitTest
    {
        public Operations _operations;

        [TestInitialize]
        public void SetUp()
        {
            _operations = new();
        }

        [TestMethod]
        public void GetName_Test()
        {
            Func<string> getNameDelegate = _operations.GetName;
            var name = getNameDelegate();

            Assert.AreEqual(name, _operations.Name);
        }

        [TestMethod]
        public void Sum_Test()
        {
            Func<int, int, int> intSumDelegate = _operations.Sum;
            var sum = intSumDelegate(3, 3);
            Assert.AreEqual(6, sum);
        }

        [TestMethod]
        public void Multiply_Test()
        {
            Func<int, int, int> multiplyDelegate = delegate (int x, int y) { return x * y; };
            var multiply = multiplyDelegate(3, 2);
            Assert.AreEqual(6, multiply);
        }

        [TestMethod]
        public void Subtract_Test()
        {
            Func<int, int, int> subtractDelegate = (int x, int y) => x - y;
            var subtract = subtractDelegate(3, 2);
            Assert.AreEqual(1, subtract);
        }
    }
}
